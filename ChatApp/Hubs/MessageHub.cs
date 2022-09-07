using ChatApp.Domain.Extensions;
using ChatApp.Domain.Models;
using ChatApp.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IDictionary<string, ConnectedUser> _connections;

        public MessageHub(IDictionary<string, ConnectedUser> connections)
        {
            _connections = connections;
        }
        public override Task OnConnectedAsync()
        {
            var connectedUser = new ConnectedUser
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


        public List<ConnectedUser> GetAllConnectedUsers() => _connections.Values.ToList();


        //sample caller codes
        public async Task SendMessageToRoom(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out ConnectedUser connectedUser))
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

        public void AddToRoom(ConnectedUser connectedUser)
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
