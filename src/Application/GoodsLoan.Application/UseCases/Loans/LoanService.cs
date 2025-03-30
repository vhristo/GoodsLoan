using AutoMapper;
using GoodsLoan.Application.Interfaces;
using GoodsLoan.Core.DTOs;
using GoodsLoan.Core.Enums;
using GoodsLoan.Core.Interfaces;

namespace GoodsLoan.Application.UseCases.Loans;

public class LoanService : ILoansService
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public LoanService(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LoanDto>> GetLoans()
    {
        var loans = await _loanRepository.GetLoans();

        return _mapper.Map<IEnumerable<LoanDto>>(loans);
    }

    public async Task<IEnumerable<LoanStatusSummaryDto>> GetLoanStatusSummary()
    {
        var summary = await _loanRepository.GetLoanStatusSummary();
        var totalAmount = summary.Sum(s => s.TotalAmount);
        var paidLoansSummary = summary.FirstOrDefault(s => s.Status == LoanStatus.Paid);
        var awaitPaymentLoansSummary = summary.FirstOrDefault(s => s.Status == LoanStatus.AwaitPayment);
        var paidPercentage = paidLoansSummary.TotalAmount / totalAmount * 100;
        var awaitPaymentPercentage = awaitPaymentLoansSummary.TotalAmount / totalAmount * 100;

        paidLoansSummary.PercentageOfPaidOrAwaitingPayment = paidPercentage;
        awaitPaymentLoansSummary.PercentageOfPaidOrAwaitingPayment = awaitPaymentPercentage;

        return summary;
    }
}
