using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsLoan.Core.Entities;

[Table("Invoice")]
public class Invoice
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public int LoanId { get; set; }

    public Loan Loan { get; set; }
}
