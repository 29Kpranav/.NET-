using ASP.NETMVC1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NETMVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //ILogger<HomeController> is an interface provided by the Microsoft.Extensions.Logging framework that allows logging of messages and events from the HomeController class.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //the Index() action method returns a ViewResult, which is typically associated with a Razor view named Index.cshtml.
        //The IActionResult interface provides a flexible way to return different types of responses from action methods. By returning an IActionResult, you can specify what type of response the action method should generate, such as a view, a file download, a JSON response, a redirect, or a custom response.
        {
            //ViewBag.UserName = "John Doe";     The ViewBag and ViewData are dynamic objects that can be used to pass data from the controller to the view when you don't want to create a dedicated model for the view.
            //ViewData["UserAge"] = 30;
            //return View();

            Student student = new Student();
            student.Name = "John";
            student.City = "New York";
            return View(student);
        }

        public IActionResult Privacy()
        {
            Student student = new Student();
            student.Name = "John";
            student.City = "New York";

            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//Here are some commonly used implementations of the IActionResult interface:

//ViewResult: Represents an HTML view response. It allows you to render a Razor view or a specific view template and pass a model to the view.

//PartialViewResult: Represents a partial HTML view response. It is used to render a partial view (a reusable portion of a view) and can also pass a model to it.

//JsonResult: Represents a JSON response. It serializes an object to JSON format and sends it back to the client.

//FileResult: Represents a response that returns a file to download. It is used to send binary file content to the client.

//ContentResult: Represents a response with a user-defined content type and content. It allows you to return plain text, XML, or any other content type.

//RedirectResult: Represents a redirect response. It instructs the client to redirect to a different URL.

//StatusCodeResult: Represents a response with a specific HTTP status code (e.g., 404 Not Found, 500 Internal Server Error).