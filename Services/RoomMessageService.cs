using chat_application.Models;
using ChatApp.Data;
using ChatApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services
{
    public class RoomMessageService : IRoomMessageService
    {
        private readonly ApplicationDbContext _db;
        public RoomMessageService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateRoomMessage(int roomId, RoomMessage roomMessage)
        {
            ChatRoom foundroom = await _db.ChatRooms.FirstOrDefaultAsync(x => x.Id == roomId);
            if (foundroom is not null)
            {
                foundroom.Messages.Add(roomMessage);
            }

            await _db.SaveChangesAsync();

        }



        public async Task<List<RoomMessage?>?> GetRoomMessagesByIdAsync(int roomId, int load = 50)
        {
            var foundMessages = await _db.ChatRooms
               .SelectMany(x => x.Messages.DefaultIfEmpty()).Where(x => x.ChatRoomId == roomId).Take(load).OrderByDescending(x => x.Timestamp).ToListAsync();

            return foundMessages;
        }
    }
}
