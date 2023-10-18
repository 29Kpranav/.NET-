using CustomerWebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//var dbHost = "localhost";
//var dbName = "dms_customer";
//var dbPassword = "P@ssw0rd121#";

var connectionString = "server=LAPTOP-F4QI0N65; database=CodeFirstDB; trusted_connection=true;";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
