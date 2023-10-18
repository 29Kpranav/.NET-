using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ArithmeticApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArithmeticController : ControllerBase
    {
        private static List<string> _messages = new List<string>();
        private readonly ILogger<ArithmeticController> _logger;

        public ArithmeticController(ILogger<ArithmeticController> logger)
        {
            _logger = logger;
        }

        // ... Your action methods ...

        [HttpGet("add")]
        public IActionResult Add(double num1, double num2)
        {
            double result = num1 + num2;
            return Ok(result);
        }

        [HttpGet("sub")]
        public IActionResult Sub(double num1, double num2)
        {
            double result = num1 - num2;
            return Ok(result);
        }

        // ... Other action methods ...

        [HttpGet("messages")]
        public IEnumerable<string> GetMessages()
        {
            return _messages;
        }

        [HttpPost("messages")]
        public IActionResult PostMessage([FromBody] string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("Message cannot be empty.");
            }

            _messages.Add(message);
            return Ok("Message added successfully.");
        }
    }
}
