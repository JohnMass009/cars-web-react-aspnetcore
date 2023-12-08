using Cars.CarsDb.Context;
using Cars.Domain.Interfaces;
using Cars.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarsDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=CarsDb;Trusted_Connection=True;"));

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ICarCategoryService, CarCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
