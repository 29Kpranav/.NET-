using TargetUrlDemo.Model;

namespace TargetUrlDemo.Service
{
    public class TargeturlService
    {
        List<WebhookPayload> list = new List<WebhookPayload>();
        public void AddDatToTarget(WebhookPayload payload) { 
        
            list.Add(payload);
            foreach(WebhookPayload x in list)
            {
                Console.WriteLine(x.Event.ToString());
                Console.WriteLine(x.Data.ToString());
            }
        }

       // public List<WebhookPayload> GetDatToTarget()
        //{
          //  return list;
            //}
    }
}
