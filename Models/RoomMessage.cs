namespace chat_application.Models
{
    public class RoomMessage
    {
        public int Id { get; set; }
        public ChatRoom RoomId { get; set; }
        public string SenderId { get; set; }
        public string IsStockCode { get; set; }
        public DateTime TimeSent { get; set; }
        public string SenderUserName { get; set; }
    }
}
