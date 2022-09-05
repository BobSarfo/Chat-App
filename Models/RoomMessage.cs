using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat_application.Models
{
    public class RoomMessage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SenderId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string SenderUsername { get; set; }
        public bool IsStockCode { get; set; }
        public DateTime Timestamp { get; set; }

        [DataType(DataType.Text)]
        public string Message { get; set; } 


        public int ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}
