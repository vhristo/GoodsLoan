using GoodsLoan.Application.Common.Mappings;
using GoodsLoan.Application.Interfaces;
using GoodsLoan.Application.UseCases.Loans;
using GoodsLoan.Core.Interfaces;
using GoodsLoan.Infrastructure.Persistence;
using GoodsLoan.Infrastructure.Persistence.Repositories;
using SQLitePCL;

namespace GoodsLoan.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ILoanRepository>(provider =>
            {
                return new LoanRepository(connectionString);
            });

            services.AddScoped<ILoansService, LoanService>();
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            Batteries.Init();
            SqliteDbInitializer.Initialize(connectionString);
            SqliteDbInitializer.Seed(connectionString);

            return services;
        }
    }
}
