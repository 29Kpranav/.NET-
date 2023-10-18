using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebhookPublisherService.Model;
using WebhookPublisherService.Models;

namespace WebhookPublisherService.Services
{
    public class WebhookService
    {
        private readonly HttpClient httpClient;
        private readonly List<Subscription> subscriptions = new List<Subscription>();

        public WebhookService()
        {
        }

        public WebhookService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void AddSubscription(Subscription subscription)
        {
            subscriptions.Add(subscription);
        }

        public List<Subscription> GetSubscriptions()
        {
            return subscriptions;
        }

        public async Task<string> TriggerWebhooks(WebhookPayload payload)
        {
            foreach (var subscription in subscriptions)
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, subscription.TargetUrl);
                    var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                    request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        return $"Webhook delivered to {subscription.TargetUrl}";
                    }
                    else
                    {
                        return $"Webhook delivery to {subscription.TargetUrl} failed with status code: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Exception occurred during webhook delivery to {subscription.TargetUrl}: {ex.Message}";
                }
            }
            return "";
        }
    }
}

