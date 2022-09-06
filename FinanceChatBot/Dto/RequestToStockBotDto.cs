namespace StockChatBot.Dto
{
    public class RequestToStockBotDto
    {
        public RequestToStockBotDto(){}
        public string? Message { get; set; }
        public int ChatRoomId { get; set; }
        public string? ChatRoomName { get; set; }
        public string? SenderConnectionId { get; set; }
        public string? RecieverConnectionId { get; set; }
        public bool IsRoomMessage { get; set; }
    }
}
