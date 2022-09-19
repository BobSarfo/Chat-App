using chat_application.Models;
using ChatApp.Data;
using ChatApp.Dtos;
using ChatApp.Hubs;
using ChatApp.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHubContext<MessageHub> _messageHub;
        private readonly IDictionary<int, ConnectedUserModel> _connections;

        public ChatRoomService(ApplicationDbContext db,
             IHubContext<MessageHub> messageHub,
            IDictionary<int, ConnectedUserModel> connections)
        {
            _db = db;
            _messageHub = messageHub;
            _connections = connections;
        }


        public async Task<List<ChatRoom>?> GetAllChatRoomsAsync()
        {
            var foundRooms = await _db.ChatRooms.ToListAsync();

            return foundRooms;
        }

        public async Task<bool> AddChatRoomAsync(string chatRoomName)
        {

            var foundRoom = await _db.ChatRooms.FirstOrDefaultAsync(x => x.RoomName == chatRoomName);

            if (foundRoom is not null)
                return false;
            var room = new ChatRoom(chatRoomName);
            _db.ChatRooms.Add(room);

            return true;
        }

        public async Task<bool> RemoveChatRoomAsync(string chatRoomName)
        {
            var foundRoom = await _db.ChatRooms.FirstOrDefaultAsync(x => x.RoomName == chatRoomName);

            if (foundRoom is null)
                return false;

            _db.ChatRooms.Remove(foundRoom);

            return true;
        }

        public async Task<string?> UpdateOnlineUserChatRoom(int chatRoomId, int userId)
        {
            var chatRooms = await GetAllChatRoomsAsync();

            var foundRoom = chatRooms?.FirstOrDefault(x => x.Id == chatRoomId);
            var previousChatRoom = _connections.Where(x => x.Key == userId).Select(x => x.Value).FirstOrDefault();

            if (previousChatRoom != null)
            {

                await _messageHub.Groups.RemoveFromGroupAsync(previousChatRoom.ConnectionIds.First(), previousChatRoom.CurrentRoomName);
                
                previousChatRoom.ConnectionIds.ForEach(async connId =>
                {
                    await _messageHub.Groups.AddToGroupAsync(connId, foundRoom.RoomName);
                });

                _connections[previousChatRoom.UserId].CurrentRoomName = foundRoom.RoomName ?? _connections[previousChatRoom.UserId].CurrentRoomName;


            }
            return foundRoom?.RoomName;
        }
    }
}
