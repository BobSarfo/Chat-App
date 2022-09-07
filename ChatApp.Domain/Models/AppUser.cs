using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Models
{
    public partial class AppUser : IdentityUser<int>
    {
        public List<ChatRoom>? ChatRooms { get; set; }

    }
}
