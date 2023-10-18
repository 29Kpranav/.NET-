// WebhookController.cs
using Microsoft.AspNetCore.Mvc;
using WebhookPublisherService.Model;
using WebhookPublisherService.Models;
using WebhookPublisherService.Services;

namespace WebhookPublisherService.Controllers
{
    [ApiController]
    [Route("api/webhooks")]
    public class WebhookController : ControllerBase
    {
        private readonly WebhookService webhookService;

        public WebhookController(WebhookService webhookService)
        {
            this.webhookService = webhookService;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Test Method");
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] Subscription subscription)
        {
            webhookService.AddSubscription(subscription);
            return Ok("Subscription successful");
        }

        [HttpPost("trigger")]
        public IActionResult Trigger([FromBody] WebhookPayload payload)
        {
            webhookService.TriggerWebhooks(payload);
            return Ok("Webhook triggered successfully");
        }

        [HttpGet("AllSubscriptions")]
        public List<Subscription> GetAll()
        {
           return webhookService.GetSubscriptions();
        }

        [HttpGet("NotifyAll")]
        public Task<string> Notify(WebhookPayload payload)
        {
            return webhookService.TriggerWebhooks(payload);
        }

    }
}

