using GoodsLoan.Core.DTOs;

namespace GoodsLoan.Application.Interfaces;

public interface ILoansService
{
    public Task<IEnumerable<LoanDto>> GetLoans();

    public Task<IEnumerable<LoanStatusSummaryDto>> GetLoanStatusSummary();
}
