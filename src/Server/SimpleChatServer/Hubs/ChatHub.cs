using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SimpleChatServer.Hubs.Clients;
using SimpleChatServer.Models.Chat;

namespace SimpleChatServer.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
