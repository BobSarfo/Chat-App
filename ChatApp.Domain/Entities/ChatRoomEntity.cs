using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChatApp.Domain.Entities
{
    public class ChatRoomEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string RoomName { get; set; }
        public DateTime DateCreated { get; private set; } = DateTime.UtcNow;

        public List<RoomMessageEntity> Messages { get; set; } = new List<RoomMessageEntity>();

        public ChatRoomEntity() { }
    }
}
