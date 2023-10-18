var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/webhook", async context =>{
    if (!context.Request.Headers.ContainsKey("Authorization"))
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return;
    }
    var apiKey = context.Request.Headers["Authorization"];
    if(apiKey != "APIKEY")
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return;
    }
    var requestBody = await context.Request.ReadFromJsonAsync<WebhookPayload>();
    Console.WriteLine($"Header: {requestBody.Header}, Body: {requestBody.Body}");
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("Webhook Ack!");
});

app.Run();

public record WebhookPayload(string Header, string Body);