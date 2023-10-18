using System;

class Program
{
    static async Task Main(string[] args)
    {
        string bootstrapServers = "localhost:9092"; // Kafka broker address
        string topic = "my_topic8";
        string groupId = "my_consumer_group";

        var producer = new KafkaProducer(bootstrapServers, topic);
        var consumer = new KafkaConsumer(bootstrapServers, groupId, topic);

        // Start a Kafka producer (send messages)
        producer.ProduceAsync("6670923");

        Console.WriteLine("Before ConsumeAsync");
        // Start a Kafka consumer (consume messages)
        //consumer.ConsumeAsync();
        await consumer.ConsumeAsync();

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}
