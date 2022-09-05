using chat_application.Models;
using ChatApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChatApp.Data.Repositories
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public ChatRoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<List<ChatRoom>?> GetAllChatRoomsAsync()
        {
            var foundRooms = await _db.ChatRooms.ToListAsync();

            return foundRooms;
        }

        public async Task<bool> AddChatRoomAsync(string chatRoomName)
        {
            var foundRoom = await _db.ChatRooms.FirstOrDefaultAsync(x => x.GroupName == chatRoomName);

            if (foundRoom is not null)
                return false;
            var room = new ChatRoom(chatRoomName);
            _db.ChatRooms.Add(room);

            return true;
        }

        public async Task<bool> RemoveChatRoomAsync(string chatRoomName)
        {
            var foundRoom = await _db.ChatRooms.FirstOrDefaultAsync(x => x.GroupName == chatRoomName);

            if (foundRoom is null)
                return false;

            _db.ChatRooms.Remove(foundRoom);

            return true;
        }
       
        public async Task<List<RoomMessage?>?> GetMessagesFromRoomIdAsync(int roomId, int load = 50)
        {
            var foundMessages = await _db.ChatRooms
               .SelectMany(x => x.Messages.DefaultIfEmpty()).Where(x => x.ChatRoomId == roomId).Take(load).OrderByDescending(x => x.Timestamp).ToListAsync();

            return foundMessages;
        }
    }
}
