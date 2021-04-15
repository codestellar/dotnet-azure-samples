using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace Codestellar.EventHubsDemo
{
    class Program
    {
        private const string connectionString = "<EVENT HUBS NAMESPACE - CONNECTION STRING>";
        private const string eventHubName = "<EVENT HUB NAME>";
        static void Main(string[] args)
        {
            // Create a producer client that you can use to send events to an event hub
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // Create a batch of events 
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                // Add events to the batch. An event is a represented by a collection of bytes and metadata. 
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First geolocation Test Event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First geolocation Test Event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First geolocation Test Event")));

                // Use the producer client to send the batch of events to the event hub
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("A batch of 3 events has been published.");
                Console.ReadKey();
            }
        }
    }
}
