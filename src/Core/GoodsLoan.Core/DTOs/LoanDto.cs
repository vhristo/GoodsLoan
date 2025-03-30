namespace GoodsLoan.Core.DTOs;

public class LoanDto
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Amount { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto>();
}
