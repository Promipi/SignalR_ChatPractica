using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server
{
    public class ChatPruebaHub : Hub
    {
        public override Task OnConnectedAsync() //cuiando se conecta un usuario
        {
            Console.WriteLine($"Usuario Conectado {Context.ConnectionId} ");
            return Task.CompletedTask;
        }

        [HubMethodName("SendMessage") ]
        public async Task SendMessage(string message) //para enviar un mensaje
        {
            await Clients.Others.SendAsync("AwaitMessage", message);
        }
    }
}
