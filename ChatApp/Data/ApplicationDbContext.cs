using chat_application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PrivateMessage> PrivateMessage { get; set; }
        public DbSet<RoomMessage> RoomMessages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatRoom>().HasData(
               new ChatRoom
               {
                   RoomName = "General",
                   DateCreated = DateTime.UtcNow,
                   Id = 1001
               },
                  new ChatRoom
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