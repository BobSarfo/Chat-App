using chat_application.Extensions;
using ChatApp.Dtos;
using Microsoft.AspNetCore.SignalR;
using System;

namespace ChatApp.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IDictionary<string, ConnectedUserDto> _connections;

        public MessageHub(IDictionary<string, ConnectedUserDto> connections)
        {
            _connections = connections;
        }
        public override Task OnConnectedAsync()
        {
            var conn = new ConnectedUserDto
            {
                ConnectionId = Context.ConnectionId,
                UserName = Context.User.GetUsername(),
                UserId = Context.User.GetUserId(),
                SelectedRoomName = "General"
            };
            _connections.TryAdd(Context.ConnectionId, conn);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _connections.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public void BroadCastMessage(string message)
        {
            Clients.All.SendAsync("ReceiveBroadcastMessage", message, message, message, message);
        }

        public async Task SendMessageToRoom(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out ConnectedUserDto connectedUser))
            {
                await Clients.Group(connectedUser.SelectedRoomName).SendAsync("ReceiveGroupMessage", message, connectedUser);

            }
        }

        public async Task SendMessageToUser(string message, string connectionId)
        {
            if (_connections.ContainsKey(connectionId))
            {
                await Clients.Clients(connectionId, Context.ConnectionId).SendAsync("ReceiveUserMessage", message);
            }
        }

        public async Task AddToRoomAsync(ConnectedUserDto connectedUser)
        {
            //room , username
            await Groups.AddToGroupAsync(Context.ConnectionId, connectedUser.SelectedRoomName);
            if (!_connections.ContainsKey(Context.ConnectionId))
            {
                _connections.Add(Context.ConnectionId, connectedUser);
            }

            await Clients.Group(connectedUser.SelectedRoomName).SendAsync("ReceiveGroupMember",$"{connectedUser.UserName} joined room");
        }
    }
}
