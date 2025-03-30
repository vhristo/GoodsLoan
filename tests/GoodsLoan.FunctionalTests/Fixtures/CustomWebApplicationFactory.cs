using GoodsLoan.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using GoodsLoan.FunctionalTests.FakeRepositories;

namespace GoodsLoan.FunctionalTests.Fixtures;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove existing repo registration
            services.RemoveAll<ILoanRepository>();

            // Register fake repository
            services.AddSingleton<ILoanRepository, FakeLoanRepository>();
        });

        return base.CreateHost(builder);
    }
}