using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace chat_application.Models
{
    public class ChatRoom
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string RoomName { get; set; }
        public DateTime DateCreated { get; set; }
        
        public List<RoomMessage> Messages { get; set; } = new List<RoomMessage>();
        public ChatRoom(string groupName)
        {
            RoomName = groupName;
            DateCreated  =  DateTime.UtcNow;
        }
        public ChatRoom() { }
    }
}
