using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebhookDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Add services if needed
                    });
                    webBuilder.Configure((hostContext, app) =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapPost("/webhook", async context =>
                            {
                                if (!context.Request.Headers.ContainsKey("Authorization"))
                                {
                                    context.Response.StatusCode = 401;
                                    return;
                                }

                                var apiKey = context.Request.Headers["Authorization"];
                                if (apiKey != "YOUR_API_KEY")
                                {
                                    context.Response.StatusCode = 401;
                                    return;
                                }

                                // Process webhook data here
                                // Example: Print request body
                                using var reader = new System.IO.StreamReader(context.Request.Body);
                                var requestBody = await reader.ReadToEndAsync();
                                Console.WriteLine(requestBody);

                                context.Response.StatusCode = 200;
                            });
                        });
                    });
                });
    }
}
