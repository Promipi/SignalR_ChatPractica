using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Chat.Client
{
    class Program
    {
        static HubConnection connection;
        static async Task Main(string[] args)
        {
            connection = new HubConnectionBuilder()
                             .WithUrl("https://localhost:5001/pruebaChatHub")
                             .Build();

            await connection.StartAsync(); //establecemmos la conexion


            connection.On<string>("AwaitMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            while(true)
            {
                var message = Console.ReadLine();
                await connection.SendAsync("SendMessage", message);
            }
        }
    }
}
