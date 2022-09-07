using Microsoft.AspNetCore.Identity;

namespace ChatApp.Infrastructure.Entities
{
    public partial class AppUserEntity : IdentityUser<int>
    {
        public List<ChatRoomEntity> ChatRooms { get; set; }
    }
}
