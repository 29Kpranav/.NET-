
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using IdentityServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityServerDemo"
)));

builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();   

var app = builder.Build();

 

app.Run();
