using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add MVC controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Amazon DynamoDB service
builder.Services.AddAWSService<IAmazonDynamoDB>();

// Add DynamoDB context for data modeling
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

var app = builder.Build();

// Enable X-Ray tracing for the application
app.UseXRay("UserApi");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable authentication and authorization
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();


// Start the application
app.Run("https://localhost:5001");
