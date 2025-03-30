using GoodsLoan.Core.Enums;

namespace GoodsLoan.Core.DTOs;

public class LoanStatusSummaryDto
{
    public LoanStatus Status { get; set; }
    public int Count { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal? PercentageOfPaidOrAwaitingPayment { get; set; }
}
