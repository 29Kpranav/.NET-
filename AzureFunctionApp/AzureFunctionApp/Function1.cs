using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionApp
{
    public static class Sum
    {
        [FunctionName("Sum")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int x = int.Parse(req.Query["x"]);
            int y = int.Parse(req.Query["y"]);

            int result = x  +  y;

            //http://localhost:7276/api/Sum?x=10&y=16 -> 26
            return new OkObjectResult(result);
            
        }

        [FunctionName("Sub")]
        public static async Task<IActionResult> Run1(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int x = int.Parse(req.Query["x"]);
            int y = int.Parse(req.Query["y"]);

            int result = x - y;

            //http://localhost:7276/api/Sum?x=10&y=16 -> -6
            return new OkObjectResult(result);

        }

        [FunctionName("mul")]
        public static async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int x = int.Parse(req.Query["x"]);
            int y = int.Parse(req.Query["y"]);

            int result = x * y;

            //http://localhost:7276/api/mul?x=10&y=16 -> 160
            return new OkObjectResult(result);

        }

        [FunctionName("power")]
        public static async Task<IActionResult> Run3(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int x = int.Parse(req.Query["x"]);
            int y = int.Parse(req.Query["y"]);

            int sum = 1;
           for(int i=1; i<=y; i++)
            {
                sum = sum * x;
            }

            //http://localhost:7276/api/power?x=2&y=3 -> 8
            return new OkObjectResult(sum);

        }
    }
}
