using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chat_application.Models
{
    public class PrivateMessage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public String SenderUsername { get; set; }
        public int ReceiverId { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string ReceiverUsername { get; set; }
        
        [DataType(DataType.Text)]
        public string Message { get; set; }
        public bool IsSeen { get; set; }
        public bool IsStockCode { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
