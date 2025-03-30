using GoodsLoan.Core.Entities;
using GoodsLoan.Core.DTOs;

namespace GoodsLoan.Core.Interfaces;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetLoans();
    Task<IEnumerable<LoanStatusSummaryDto>> GetLoanStatusSummary();
}
