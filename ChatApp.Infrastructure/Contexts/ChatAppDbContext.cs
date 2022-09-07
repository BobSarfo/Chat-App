using ChatApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Contexts
{
    public partial class ChatAppDbContext : IdentityDbContext <AppUser, IdentityRole<int>, int>, IChatAppContext
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