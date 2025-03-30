using GoodsLoan.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using GoodsLoan.FunctionalTests.Fixtures;

namespace GoodsLoan.FunctionalTests.Controllers;

public class LoanApiTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public LoanApiTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetLoan_ShouldReturnSuccess()
    {
        //var request = new
        //{
        //    Number = "L003",
        //    FirstName = "Alice",
        //    LastName = "Brown",
        //    Amount = 2000,
        //    Status = 1
        //};
        //
        //var response = await _client.PostAsJsonAsync("/api/loan", request);
        var response = await _client.GetFromJsonAsync<List<LoanDto>>("/api/loan");
       // response.EnsureSuccessStatusCode();

        //var result = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
        //Assert.True(response["id"] > 0);
    }
}
