using GoodsLoan.Application.Interfaces;
using GoodsLoan.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GoodsLoan.Api.Controllers;

[ApiController]
[Route("api")]
[Produces("application/json")]
public class LoansController : ControllerBase
{
    private readonly ILoansService _loansService;

    public LoansController(ILoansService loanService)
    {
        _loansService = loanService;
    }

    /// <summary>
    /// Get all loans
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("loans")]
    [ProducesResponseType<IEnumerable<LoanDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var loans = await _loansService.GetLoans();

        return Ok(loans);
    }

    /// <summary>
    /// Get loan summary
    /// </summary>
    /// <returns></returns>
    [HttpGet("loans/summary")]
    [ProducesResponseType<IEnumerable<LoanStatusSummaryDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLoanSummary()
    {
        var data = await _loansService.GetLoanStatusSummary();

        return Ok(data);
    }
}
