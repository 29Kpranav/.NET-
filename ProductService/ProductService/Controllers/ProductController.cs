using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 10.99M },
        new Product { Id = 2, Name = "Product 2", Price = 20.99M }
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_products);
    }
}
