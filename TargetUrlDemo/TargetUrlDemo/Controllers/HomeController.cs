using Microsoft.AspNetCore.Mvc;
using TargetUrlDemo.Model;
using TargetUrlDemo.Service;

namespace TargetUrlDemo.Controllers
{
    [ApiController]
    [Route("api/TestUrl")]
    public class HomeController : ControllerBase
    {
        private readonly TargeturlService service;

        public HomeController(TargeturlService service)
        {
            this.service = service;
        }

        [HttpPost("Target")]
        public void addData(WebhookPayload payload)
        {
            //Console.WriteLine("Lets go..");
            service.AddDatToTarget(payload);
        }

        //[HttpGet("GetTarget")]
        //public List<WebhookPayload> getData()
        //{
            //Console.WriteLine("Lets go..");
            // return service.GetDatToTarget();
        //}

    }
}




//// https://localhost:7063/api/TestUrl/Target
///  https://localhost:7063/api/TestUrl/GetTarget
