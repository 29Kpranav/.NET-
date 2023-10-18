class Program
{
    static void Main(string[] args)
    {
        string bootstrapServers = "localhost:9092"; // Kafka broker address
        string topic = "my_topic";
        string groupId = "my_consumer_group";

        var producer = new KafkaProducer(bootstrapServers, topic);
        var consumer = new KafkaConsumer(bootstrapServers, groupId, topic);

        // Start a Kafka producer (send messages)
        producer.ProduceAsync("Hello, Kafka!");

        // Start a Kafka consumer (consume messages)
        consumer.Consume();

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}
