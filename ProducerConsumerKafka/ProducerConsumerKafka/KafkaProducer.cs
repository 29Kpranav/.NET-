using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class KafkaProducer
{
    private readonly string bootstrapServers;
    private readonly string topic;

    public KafkaProducer(string bootstrapServers, string topic)
    {
        this.bootstrapServers = bootstrapServers;
        this.topic = topic;
    }

    public async Task ProduceAsync(string message)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
        };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                var deliveryResult = await producer.ProduceAsync(
                    topic,
                    new Message<Null, string> { Value = message }
                );

                Console.WriteLine($"Produced message '{message}' to '{deliveryResult.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}
