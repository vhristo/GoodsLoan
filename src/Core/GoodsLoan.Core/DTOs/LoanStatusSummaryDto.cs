using GoodsLoan.Core.Enums;
using System.Text.Json.Serialization;

namespace GoodsLoan.Core.DTOs;

public class LoanStatusSummaryDto
{
    public LoanStatus Status { get; set; }
    public int Count { get; set; }
    public decimal TotalAmount { get; set; }
}
