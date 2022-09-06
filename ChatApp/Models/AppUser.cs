using Microsoft.AspNetCore.Identity;

namespace chat_application.Models
{
    public partial class AppUser : IdentityUser<int>
    {
        public ICollection<ChatRoom> ChatRooms { get; set; }

        public ICollection<PrivateMessage> PrivateMessages { get; set; }   

    }
}
