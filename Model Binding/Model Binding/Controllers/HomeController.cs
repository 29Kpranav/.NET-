using Microsoft.AspNetCore.Mvc;
using Model_Binding.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Model_Binding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Model Binding

        [BindProperty(Name="country", SupportsGet = true)]
        public string country { get; set; }      //india assign here

        [Route("GetString/{name?}/{country?}")]
        public string GetString(TestClass testClass)
        {
            return testClass.name;
        }

        //[Route("GetString/{names?}/{countries?}")]
        //public string GetString([ModelBinder(Name="names")] string name) {
        //    return name;
        //}

        //localhost:xyz/GetString/pk/india
        //localhost:xyz/GetString/pk/india?country=usa  ....still india will assign as routes preference comes first 
        // if you want to get values from route and other prefernce neglegible then use below..

        //public string GetString([FromQuery] string name){
        //Return name;
        //{

    }
}