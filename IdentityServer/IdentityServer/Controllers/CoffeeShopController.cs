using IdentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ICoffeeShopService coffeeShopServices;
        public CoffeeShopController(ICoffeeShopService coffeeShopService)
        {
           this.coffeeShopServices = coffeeShopService; 
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var coffeShops = await coffeeShopServices.List();
            return Ok(coffeShops);
        }
    }
}
