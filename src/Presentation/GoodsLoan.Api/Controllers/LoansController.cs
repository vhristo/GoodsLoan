using GoodsLoan.Application.Interfaces;
using GoodsLoan.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GoodsLoan.Api.Controllers;

[Route("api")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly ILoansService _loansService;

    public LoansController(ILoansService loanService)
    {
        _loansService = loanService;
    }

    [HttpGet("loans")]
    [ProducesResponseType<IEnumerable<LoanDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var loans = await _loansService.GetLoans();

        return Ok(loans);
    }

    [HttpGet("loans/summary")]
    [ProducesResponseType<IEnumerable<LoanStatusSummaryDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLoanSummary()
    {
        var data = await _loansService.GetLoanStatusSummary();

        return Ok(data);
    }
}
