using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AddActiveDirectory.Data;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AddActiveDirectoryContextConnection") ?? throw new InvalidOperationException("Connection string 'AddActiveDirectoryContextConnection' not found.");

builder.Services.AddDbContext<AddActiveDirectoryContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AddActiveDirectoryContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddMicrosoftIdentityUI();

// Configure authentication
builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration.GetSection("AzureAd"));

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
