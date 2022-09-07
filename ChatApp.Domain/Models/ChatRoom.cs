using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChatApp.Domain.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public DateTime DateCreated { get; set; }
        public List<RoomMessage>? Messages { get; set; } = new List<RoomMessage>();

        public static implicit operator ChatRoom?(List<RoomMessage>? v)
        {
            throw new NotImplementedException();
        }
    }
}
