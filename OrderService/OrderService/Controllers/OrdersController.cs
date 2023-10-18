using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    public static List<Order> _orders = new List<Order>();
    private readonly HttpClient _httpClient;

    private OrdersController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:7001"); // Change to the ProductService URL
    }

    private async Task<Product> GetProductDetails(int productId)
    {
        var response = await _httpClient.GetAsync($"/api/products/{productId}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);
            return product;
        }
        return null;
    }


    [HttpPost]
    public IActionResult Create(Order order)
    {
        _orders.Add(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

}
