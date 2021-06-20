using System;
using System.Threading.Tasks;
using Dapr;
using Dapr.Client;

namespace DaprCounter
{

    class Program
    {     
        static async Task Main(string[] args)
        {

            var daprClient = new DaprClientBuilder().Build();

            var counter = await daprClient.GetStateAsync<int>("statestore","counter");

            while(true)
            {
                Console.WriteLine($"Counter = {counter++}");

                await daprClient.SaveStateAsync("statestore","counter", counter);

                await Task.Delay(1000);
            }
        }
            
    }

}
