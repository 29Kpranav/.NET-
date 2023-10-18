using Confluent.Kafka;
using System;

class KafkaConsumer
{
    private readonly string bootstrapServers;
    private readonly string groupId;
    private readonly string topic;

    public KafkaConsumer(string bootstrapServers, string groupId, string topic)
    {
        this.bootstrapServers = bootstrapServers;
        this.groupId = groupId;
        this.topic = topic;
    }

    public void Consume()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false, // Turn off auto commit to control offsets manually
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe(topic);

            while (true)
            {
                try
                {
                    var consumeResult = consumer.Consume();

                    Console.WriteLine($"Consumed message: Key: {consumeResult.Message.Key}, Value: {consumeResult.Message.Value}");

                    // Manually commit the offset
                    consumer.Commit(consumeResult);
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error while consuming message: {e.Error.Reason}");
                }
            }
        }
    }
}
