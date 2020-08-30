using System;
using System.Threading.Tasks;
using SimpleChatServer.Models.Chat;

namespace SimpleChatServer.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(Message message);
    }
}
