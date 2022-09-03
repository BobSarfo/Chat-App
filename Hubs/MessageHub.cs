using Microsoft.AspNetCore.SignalR;
using System;

namespace ChatApp.Hubs
{
    public class MessageHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public void BroadCastMessage(string message)
        {
            Clients.All.SendAsync("ReceiveBroadcast", message, message, message, message)
        }
    }
}
