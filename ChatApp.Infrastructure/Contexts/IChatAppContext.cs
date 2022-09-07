using ChatApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Contexts
{
    internal interface IChatAppContext
    {
        public DbSet<RoomMessageEntity> RoomMessages { get; set; }
        public DbSet<ChatRoomEntity> ChatRooms { get; set; }
    }
}
