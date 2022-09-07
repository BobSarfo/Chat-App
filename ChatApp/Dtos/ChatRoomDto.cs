using ChatApp.Domain.Models;

namespace ChatApp.Dtos
{
    public class ChatRoomDto
    {
        public List<ChatRoom> RoomNames { get; set; } = new ();
        public string SelectedRoom { get; set; } = "General";
        public int SelectedRoomId { get; set; } = 1;

        public List<RoomMessage> RoomMessages { get; set; } = new ();
    }
} 
