using ChatApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChatApp.Infrastructure.Contexts
{
    public class ChatAppDbContext : IdentityDbContext<AppUserEntity, IdentityRole<int>, int>, IChatAppContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {
        }

        public DbSet<RoomMessageEntity> RoomMessages { get; set; }
        public DbSet<ChatRoomEntity> ChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatRoomEntity>().HasData(
                new ChatRoomEntity()
                {
                    RoomName = "General",
                    Id = 1001
                },
                new ChatRoomEntity()
                {
                    RoomName = "Coding",
                    Id = 1002
                }
           ); ;
            base.OnModelCreating(builder);
        }

    }
}