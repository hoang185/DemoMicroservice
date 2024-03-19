using Microsoft.EntityFrameworkCore;
using CustomerWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//database
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbHost = "HOANGVU";
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbName = "dms_customer";
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var connectionString = $"Server={dbHost};Database={dbName};Integrated Security=True;Encrypt=false";
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";
builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
