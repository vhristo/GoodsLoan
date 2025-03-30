using GoodsLoan.Core.DTOs;
using GoodsLoan.Core.Entities;
using GoodsLoan.Core.Interfaces;
using GoodsLoan.Core.Enums;

namespace GoodsLoan.FunctionalTests.FakeRepositories;

public class FakeLoanRepository : ILoanRepository
{
    private readonly IList<Loan> _loans = new List<Loan>();
    private readonly IList<LoanStatusSummaryDto> _summary = new List<LoanStatusSummaryDto>();

    public FakeLoanRepository()
    {
        _loans.Add(new Loan
        {
            Id = 1,
            Number = "TestLoan1",
            FirstName = "F1",
            LastName = "L1",
            Amount = 1000,
            Status = LoanStatus.Created,
            Invoices = new List<Invoice>
            {
                new() {
                    Id = 1,
                    Amount = 100,
                    LoanId = 1
                }
            }
        });

        _loans.Add(new Loan
        {
            Id = 2,
            Number = "TestLoan2",
            FirstName = "F2",
            LastName = "L2",
            Amount = 2000,
            Status = LoanStatus.AwaitPayment,
            Invoices = new List<Invoice>
            {
                new() {
                    Id = 2,
                    Amount = 200,
                    LoanId = 2
                }
            }
        });

        _loans.Add(new Loan
        {
            Id = 3,
            Number = "TestLoan3",
            FirstName = "F3",
            LastName = "L3",
            Amount = 3000,
            Status = LoanStatus.Paid,
            Invoices = new List<Invoice>
            {
                new() {
                    Id = 3,
                    Amount = 300,
                    LoanId = 3
                }
            }
        });

        _summary.Add(new LoanStatusSummaryDto
        {
            Status = LoanStatus.Created,
            Count = 1,
            TotalAmount = 1000
        });

        _summary.Add(new LoanStatusSummaryDto
        {
            Status = LoanStatus.AwaitPayment,
            Count = 1,
            TotalAmount = 2000
        });

        _summary.Add(new LoanStatusSummaryDto
        {
            Status = LoanStatus.Paid,
            Count = 1,
            TotalAmount = 3000
        });
    }
    public Task<IEnumerable<Loan>> GetLoans()
    {
        return Task.FromResult<IEnumerable<Loan>>(_loans);
    }

    public Task<IEnumerable<LoanStatusSummaryDto>> GetLoanStatusSummary()
    {
        return Task.FromResult<IEnumerable<LoanStatusSummaryDto>>(_summary);
    }
}
