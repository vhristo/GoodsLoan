## Goods Loan System


### Description

This is a simple goods loan system. It follows the [Clean Architecture pattern](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture).


The system has two main entities: **Loan** and **Invoice**.
A loan can have multiple invoices. The system has the following features:

### Database Schema

#### Table "Loan"
|Column|Type|PK|UNIQUE|AUTOINCREMENT|
|--|--|--|--|--|
|Id|INTEGER|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|Number|TEXT||:heavy_check_mark:||
|FirstName|TEXT|
|LastName|TEXT|
|Amount|Numeric|
|Status|INTEGER|

#### Table "Invoice"

|Column|Type|PK|UNIQUE|AUTOINCREMENT|FOREIGN KEY|
|--|--|--|--|--|--|
|Id|INTEGER|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|Amount|NUMERIC|
|LoanId|NUMERIC||||:heavy_check_mark:|

### How to run

1. Build the solution
1. Start the GoodsLoan.Api project
1. Open `https://localhost:7074/swagger/index.html`

There are two endpoints:

```GET: /api/loans```

```GET: /api/loans/summary```