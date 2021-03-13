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

        public async Task JoinGroup(string groupName) //para unirnos a un grupo
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task ExitGroup(string groupName) //salir de un grupo
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        [HubMethodName("SendMessage") ]
        public async Task SendMessage(string message, string groupName) //enviar mensjae
        {
            await Clients.OthersInGroup(groupName).SendAsync("AwaitMessage", message);
        }


    }
}
