## Проект Cars

## Обновление прокси-классов Entity Framework из базы MS Sql

Команда ниже указана для Packege Manager Console (VS menu -> Tools -> Nuget Package Manager -> Packege Manager Console)
Startup проектом должен быть `Cars.CarsDb`

`Scaffold-DbContext "Server=<адрес сервера>;Database=CarsDb;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -Context CarsDbContext -ContextDir Context -OutputDir Models`
