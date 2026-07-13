using System;
using System.Threading;
using System.Threading.Tasks;

namespace Training.Week4.Kafka
{
    // mock simulator client to avoid Confluent.Kafka dependency issues during local compilation
    public class MockKafkaBroker
    {
        public event Action<string> OnMessageReceived;

        public void Publish(string topic, string message)
        {
            Console.WriteLine($"[Kafka Producer] Publishing to '{topic}': {message}");
            Task.Run(() =>
            {
                Thread.Sleep(500); // network latency
                OnMessageReceived?.Invoke(message);
            });
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- kafka integration client demo ---");

            var broker = new MockKafkaBroker();

            // 1. Setup Consumer Subscription
            broker.OnMessageReceived += (msg) =>
            {
                Console.WriteLine($"[Kafka Consumer] Received event packet -> "{msg}"");
            };

            // 2. Publish Events (Producer)
            broker.Publish("event-topic", "New registration: Amit Sharma registered for Summer Music.");
            broker.Publish("event-topic", "Category preference saved: Food Category saved for Deepa Nair.");

            Thread.Sleep(2000); // wait for background threads
        }
    }
}