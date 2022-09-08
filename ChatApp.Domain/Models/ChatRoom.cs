using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public DateTime DateCreated { get; set; }
        public List<RoomMessage>? Messages { get; set; } = new List<RoomMessage>();

    }
}
