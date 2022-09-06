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
            var connectedUser = new ConnectedUserDto
            {
                ConnectionId = Context.ConnectionId,
                UserName = Context.User.GetUsername(),
                UserId = Context.User.GetUserId(),
                SelectedRoomName = "General"
            };
            
            _connections.TryAdd(Context.ConnectionId, connectedUser);

            AddToRoom(connectedUser);

            Clients.All.SendAsync("UsersOnline", GetAllConnectedUsers());
           
            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _connections.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }


        public List<ConnectedUserDto> GetAllConnectedUsers() => _connections.Values.ToList();


        //sample caller codes
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

        public void AddToRoom(ConnectedUserDto connectedUser)
        {
            //room , username
             Groups.AddToGroupAsync(Context.ConnectionId, connectedUser.SelectedRoomName);
            if (!_connections.ContainsKey(Context.ConnectionId))
            {
                _connections.Add(Context.ConnectionId, connectedUser);
            }

            Clients.Group(connectedUser.SelectedRoomName).SendAsync("ReceiveGroupMember",$"{connectedUser.UserName} joined room");
        }
    }
}
