using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


try
{
    app.MapControllers();
    //The code that causes the error goes here.
}
catch (ReflectionTypeLoadException ex)
{
    StringBuilder sb = new StringBuilder();
    foreach (Exception exSub in ex.LoaderExceptions)
    {
        sb.AppendLine(exSub.Message);
        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
        if (exFileNotFound != null)
        {
            if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
            {
                sb.AppendLine("Fusion Log:");
                sb.AppendLine(exFileNotFound.FusionLog);
            }
        }
        sb.AppendLine();
    }
    string errorMessage = sb.ToString();
    //Display or log the error based on your application.
}

//app.UseRouting();

app.Run();
