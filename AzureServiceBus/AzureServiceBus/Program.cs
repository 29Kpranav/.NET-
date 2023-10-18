using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

class Program
{
    const string ServiceBusConnectionString = "Your_Service_Bus_Connection_String";
    const string QueueName = "Your_Queue_Name";
    static IQueueClient queueClient;

    static async Task Main(string[] args)
    {
        queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

        // Send messages to the queue
        await SendMessageAsync("Message 1");
        await SendMessageAsync("Message 2");
        await SendMessageAsync("Message 3");

        // Receive and process messages from the queue
        RegisterOnMessageHandlerAndReceiveMessages();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        await queueClient.CloseAsync();
    }

    static async Task SendMessageAsync(string messageBody)
    {
        var message = new Message(Encoding.UTF8.GetBytes(messageBody));
        await queueClient.SendAsync(message);
        Console.WriteLine($"Sent message: {messageBody}");
    }

    static void RegisterOnMessageHandlerAndReceiveMessages()
    {
        var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
        {
            MaxConcurrentCalls = 1,
            AutoComplete = false
        };

        queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
    }

    static async Task ProcessMessagesAsync(Message message, CancellationToken token)
    {
        string messageBody = Encoding.UTF8.GetString(message.Body);
        Console.WriteLine($"Received message: {messageBody}");

        // Simulate processing
        await Task.Delay(2000);

        await queueClient.CompleteAsync(message.SystemProperties.LockToken);
    }

    static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
        Console.WriteLine($"Message handler encountered an exception: {exceptionReceivedEventArgs.Exception}");
        return Task.CompletedTask;
    }
}
