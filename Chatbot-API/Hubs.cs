using Chatbot_API.DTOs.Responses;
using Microsoft.AspNetCore.SignalR;

namespace Chatbot_API
{
    public class Hubs
    {
        public class ChatHub : Hub
        {
            public Task SendMessage(MessageResponse res)               // Two parameters accepted
            {
                return Clients.All.SendAsync("ReceiveOne", res);    // Note this 'ReceiveOne' 
            }


            public string GetConnectionId()
            {
                return Context.ConnectionId;
            }
        }
    }
}
