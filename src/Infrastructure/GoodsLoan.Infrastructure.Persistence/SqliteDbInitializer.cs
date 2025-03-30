using Microsoft.Data.Sqlite;

namespace GoodsLoan.Infrastructure.Persistence;

public static class SqliteDbInitializer
{
    public static void Initialize(string connectionString)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
			-- CLEAN UP THE DATABASE
			DROP TABLE IF EXISTS 'Invoice';
			DROP TABLE IF EXISTS 'Loan';

			-- Enable foreign key support
			PRAGMA foreign_keys = ON;

			-- CREATE TABLES	
            CREATE TABLE 'Loan' (
				'Id' INTEGER UNIQUE,
				'Number' TEXT UNIQUE,
				'FirstName' TEXT,
				'LastName' TEXT,
				'Amount' NUMERIC,
			'Status' INTEGER,
				PRIMARY KEY('Id' AUTOINCREMENT)
			);

			CREATE TABLE 'Invoice' (
				'Id' INTEGER UNIQUE,
				'Amount' NUMERIC,
				'LoanId' INTEGER,
				PRIMARY KEY('Id' AUTOINCREMENT),
				FOREIGN KEY('LoanId') REFERENCES Loan(Id)
			);
			";
        cmd.ExecuteNonQuery();
    }

	public static void Seed(string connectionString)
	{
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = @"
			-- SEED DATA

			INSERT INTO Loan
			(Number, FirstName, LastName, Amount, Status)
			VALUES
			('LO-001', 'Georgi', 'V.', 1000, 0);

			INSERT INTO Loan
			(Number, FirstName, LastName, Amount, Status)
			VALUES
			('LO-002', 'Hristo', 'G.', 2000, 1);

			INSERT INTO Loan
			(Number, FirstName, LastName, Amount, Status)
			VALUES
			('LO-003', 'Deni', 'K.', 3000, 2);

			INSERT INTO Loan
			(Number, FirstName, LastName, Amount, Status)
			VALUES
			('LO-004', 'Adi', 'V.', 3000, 2);

			INSERT INTO Loan
			(Number, FirstName, LastName, Amount, Status)
			VALUES
			('LO-005', 'Kris', 'V.', 2500, 1);

			--Insert Invoices data
			INSERT INTO Invoice	
			(Amount, LoanId)
			VALUES
			(100, 1);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(200, 1);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(300, 2);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(400, 2);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(500, 3);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(600, 3);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(700, 4);

			INSERT INTO Invoice
			(Amount, LoanId)
			VALUES
			(800, 4);
			";
        cmd.ExecuteNonQuery();
    }
}
