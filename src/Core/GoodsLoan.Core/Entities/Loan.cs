using GoodsLoan.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsLoan.Core.Entities;

[Table("Loan")]
public class Loan
{
    [Key]
    public int Id { get; set; }

    [MaxLength(15)]
    public string Number { get; set; } = string.Empty;

    [MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string LastName { get; set; } = string.Empty;

    public double Amount { get; set; }

    public LoanStatus Status { get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
