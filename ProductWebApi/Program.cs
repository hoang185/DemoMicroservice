using Microsoft.EntityFrameworkCore;
using ProductWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbHost = "HOANGVU";
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbName = "dms_product";
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var dbPassword = "123456789@";

//var connectionString = $"Server={dbHost};Database={dbName};Integrated Security=True;Encrypt=false";
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";
builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
