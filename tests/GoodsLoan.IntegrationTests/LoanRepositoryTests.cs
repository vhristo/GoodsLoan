using Microsoft.Data.Sqlite;
using GoodsLoan.Core.Interfaces;
using GoodsLoan.Infrastructure.Persistence.Repositories;

namespace GoodsLoan.IntegrationTests;

public class LoanRepositoryTests : IDisposable
{
    private const string ConnectionString = "Data Source=InMemoryDb;Mode=Memory;Cache=Shared";
    private readonly SqliteConnection _persistentConnection;
    private readonly ILoanRepository _repository;


    public LoanRepositoryTests()
    {
        SQLitePCL.Batteries.Init(); // initialize the SQLite provider

        _persistentConnection = new SqliteConnection(ConnectionString);
        _persistentConnection.Open();

        InitializeSchema(_persistentConnection);

        _repository = new LoanRepository(ConnectionString);
    }

    [Fact]
    public async Task GetLoans_ShouldReturnData()
    {
        // Arrange
        using var command = _persistentConnection.CreateCommand();

        command.CommandText = @"
            INSERT INTO Loan (Number, FirstName, LastName, Amount, Status) VALUES ('L1', 'F1', 'L1', 1000, 0);
            INSERT INTO Loan (Number, FirstName, LastName, Amount, Status) VALUES ('L2', 'F2', 'L2', 2000, 1);
        ";

        command.ExecuteNonQuery();

        // Act
        var loans = await _repository.GetLoans();

        // Assert
        Assert.Single(loans);
        Assert.Equal("L1", loans.First().FirstName);
    }

    public void Dispose()
    {
        _persistentConnection.Dispose();
    }

    private void InitializeSchema(SqliteConnection connection)
    {
        using var command = connection.CreateCommand();

        command.CommandText = @"
        PRAGMA foreign_keys = ON;

        CREATE TABLE IF NOT EXISTS Loan (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Number TEXT UNIQUE,
            FirstName TEXT NOT NULL,
            LastName TEXT NOT NULL,
            Amount NUMERIC NOT NULL,
            Status INTEGER NOT NULL
        );

        CREATE TABLE IF NOT EXISTS Invoice (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Amount NUMERIC NOT NULL,
            LoanId INTEGER NOT NULL,
            FOREIGN KEY (LoanId) REFERENCES Loan(Id) ON DELETE CASCADE
        );
    ";

        command.ExecuteNonQuery();
    }
}
