namespace StockChatBot.Dto
{
    public class RequestToStockBot
    {
        public RequestToStockBot(){}
        public string? Message { get; set; }
        public string? ChatRoomName { get; set; }
        public int ChatRoomId { get; set; }
        public string? SenderConnectionId { get; set; }
        public string? RecieverConnectionId { get; set; }
        public bool IsRoomMessage { get; set; }
    }
}
