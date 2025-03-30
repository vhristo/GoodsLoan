using GoodsLoan.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using GoodsLoan.FunctionalTests.Fixtures;

namespace GoodsLoan.FunctionalTests.Controllers;

public class LoanApiTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>

{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetLoan_ShouldReturnSuccess()
    {
        var response = await _client.GetFromJsonAsync<List<LoanDto>>("/api/loan");

        Assert.True(response.Count > 0);
    }
}
