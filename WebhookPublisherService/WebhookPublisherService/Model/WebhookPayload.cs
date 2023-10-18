namespace WebhookPublisherService.Model
{
    public class WebhookPayload
    {
        public string Event { get; set; }
        public object Data { get; set; }
    }

}
