## ������ Cars

## ���������� ������-������� Entity Framework �� ���� MS Sql

������� ���� ������� ��� Packege Manager Console (VS menu -> Tools -> Nuget Package Manager -> Packege Manager Console)
Startup �������� ������ ���� `Cars.CarsDb`

`Scaffold-DbContext "Server=<����� �������>;Database=CarsDb;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -Context CarsDbContext -ContextDir Context -OutputDir Models`
