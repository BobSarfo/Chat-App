using chat_application.Extensions;
using ChatApp.Dtos;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatApp.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IDictionary<int, ConnectedUserModel> _connections;

        public MessageHub(IDictionary<int, ConnectedUserModel> connections)
        {
            _connections = connections;
        }
        public override async Task OnConnectedAsync()
        {
            var username = Context.User.GetUsername();
            var userId = Context.User.GetUserId();



            if (!_connections.TryGetValue(userId, out var connectedUserModel))
            {
                var connectedUser = new ConnectedUserModel
                {
                    ConnectionIds = new List<string> { Context.ConnectionId },
                    UserName = username,
                    UserId = userId,
                    CurrentRoomName = "General"
                };

                _connections.TryAdd(userId, connectedUser);
                await AddToRoom(connectedUser);
            }
            else
            {
                connectedUserModel.ConnectionIds.Add(Context.ConnectionId);
               await AddToRoom(connectedUserModel);

            }


           await base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User.GetUserId();

            if (!_connections.TryGetValue(userId, out var connectedUserModel))
            {
                connectedUserModel.ConnectionIds.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }


        public List<ConnectedUserModel> GetAllConnectedUsers() => _connections.Values.ToList();


        //sample caller codes
        public async Task SendMessageToRoom(string message)
        {
            var userId = Context.UserIdentifier;
            Clients.Users(userId, message);
            //var userId = Context.User.GetUserId();

            //if (_connections.TryGetValue(userId, out ConnectedUserModel connectedUser))
            //{
            //    await Clients.Group(connectedUser.CurrentRoomName).SendAsync("ReceiveGroupMessage", message, connectedUser);

            //}
        }

        public async Task SendMessageToUser(string message, int senderUserId, int receiverUserId)
        {
            var userId = Context.User.GetUserId();

            if (_connections.ContainsKey(userId))
            {
                
                await Clients.User(userId.ToString()).SendAsync("ReceiveUserMessage", message);
            }
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task LeaveRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task AddToRoom(ConnectedUserModel connectedUser)
        {
            await JoinRoom(connectedUser.CurrentRoomName);

            if (!_connections.ContainsKey(connectedUser.UserId))
            {
                _connections.Add(connectedUser.UserId, connectedUser);
            }

            await Clients.Group(connectedUser.CurrentRoomName).SendAsync("ReceiveGroupMember", $"{connectedUser.UserName} joined room");
        }
    }
}
