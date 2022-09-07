using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Contexts;
using ChatApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data.Contexts
{
    public class ChatAppDbContext : IdentityDbContext<AppUserEntity, IdentityRole<int>, int>, IChatAppContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<RoomMessageEntity> RoomMessages { get; set; }
        public DbSet<ChatRoomEntity> ChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatRoomEntity>().HasData(
               new ChatRoomEntity
               {
                   RoomName = "General",
                   DateCreated = DateTime.UtcNow,
                   Id = 1001
               },
                  new ChatRoomEntity
                  {
                      RoomName = "Coding",
                      DateCreated = DateTime.UtcNow,
                      Id = 1002
                  }
           );
            base.OnModelCreating(builder);
        }

    }
}