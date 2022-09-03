using Microsoft.AspNetCore.Identity;

namespace chat_application.Models
{
    public partial class User : IdentityUser<int>
    {
        public ICollection<ChatRoom> ChatRooms { get; set; }

        public ICollection<PrivateMessage> PrivateMessages { get; set; }   

    }
}
