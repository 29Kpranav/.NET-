
using Middleware.Middleware;

//app.Use().UseCustomMiddleware //.. use when other files' middleware executed before use this comment all middleware here

//Custom Middlewares
/*void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
{
    

    
}*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//Middleware A
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("\n Middleware A (before)");
    await next();
    await context.Response.WriteAsync("\n Middleware A (After)");
});

//Middleware B
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("\n Middleware B (before)");
    await next();
    await context.Response.WriteAsync("\n Middleware B (After)");
});

app.UseCustomMiddleware();
//Middleware C
app.Run(async context =>
{
    await context.Response.WriteAsync("\n Middleware C ");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
