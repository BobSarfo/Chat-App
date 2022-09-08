using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Entities
{
    public partial class AppUser : IdentityUser<int>
    {
        public List<ChatRoomEntity> ChatRooms { get; set; }
    }
}
