using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat_application.Models
{
    public class ChatRoom
    {
        public ChatRoom(string groupName)
        {
            GroupName = groupName;
            DateCreated  =  DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Key, Column(TypeName = "nvarchar(256)")]
        public string GroupName { get; set; }
        public DateTime DateCreated { get; set; }
        List<RoomMessage> Messages { get; set; } = new List<RoomMessage>();
    }
}
