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



            Console.Write("Digite el grupo al que te uniras : ");
            var nameGroup = Console.ReadLine();

            await connection.SendAsync("JoinGroup", nameGroup);

            


            connection.On<string>("AwaitMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            while(true)
            {
                var message = Console.ReadLine();
                await connection.SendAsync("SendMessage", message , nameGroup); //enviamos el mensaje
            }
        }
    }
}
