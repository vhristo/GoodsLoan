using GoodsLoan.Core.DTOs;
using GoodsLoan.Core.Entities;
using GoodsLoan.Core.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace GoodsLoan.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly string _connectionString;

    public LoanRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Loan>> GetLoans()
    {
        using IDbConnection db = new SqliteConnection(_connectionString);
        var query = @"SELECT
                        l.Id,
                        l.Number,
                        l.FirstName,
                        l.LastName,
                        l.Amount,
                        l.Status,
                        i.Id,
                        i.Amount,
                        i.LoanId
                      FROM Loan l
                      INNER JOIN Invoice i ON l.Id = i.LoanId
                      ORDER BY l.Id";

        var loanDictionary = new Dictionary<int, Loan>();
        var result = await db.QueryAsync<Loan, Invoice, Loan>(
            query,
            (loan, invoice) =>
            {
                // Check if loan is already added
                if (!loanDictionary.TryGetValue(loan.Id, out var existingLoan))
                {
                    existingLoan = loan;
                    existingLoan.Invoices = new List<Invoice>();
                    loanDictionary.Add(existingLoan.Id, existingLoan);
                }

                // Add invoice only if it exists (can be null in LEFT JOIN)
                if (invoice != null && invoice.Id != 0)
                {
                    existingLoan.Invoices.Add(invoice);
                }

                return existingLoan;
            },
            splitOn: "Id" // First "Id" is Loan.Id, second is Invoice.Id
        );

        return loanDictionary.Values.ToList();
    }

    public async Task<IEnumerable<LoanStatusSummaryDto>> GetLoanStatusSummary()
    {
        using IDbConnection db = new SqliteConnection(_connectionString);
        var query = @"SELECT
                        Status,
                        COUNT(*) AS Count,
                        SUM(Amount) AS TotalAmount
                      FROM Loan
                      GROUP BY Status;";
        return await db.QueryAsync<LoanStatusSummaryDto>(query);
    }
}
