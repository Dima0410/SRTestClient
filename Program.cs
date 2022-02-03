using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using SRTestClient.Models;


namespace SRTestClient
{
    internal class Program
    {
        static HubConnection hubConnection;

        static async Task Main(string[] args)
        {
            await InitSignalRConnection();

            hubConnection.On<object>("send", obj =>
            {
                
            });


            
            
            // If Stream

            //var stream = hubConnection.StreamAsync<int>("IntStream");

            //if (Console.ReadKey().Key == ConsoleKey.Tab)
            //{
            //    await foreach (var item in stream)
            //    {
            //        Console.WriteLine($"Iteration items = {item}");
            //    }
            //}

            //Console.WriteLine("Stream from server completed");

            

            while (Console.ReadKey().Key != ConsoleKey.Enter);
        }

        private static Task InitSignalRConnection()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:34235/testData")
                .WithAutomaticReconnect()
                .Build();

            return hubConnection.StartAsync();            
        }
    }
}
