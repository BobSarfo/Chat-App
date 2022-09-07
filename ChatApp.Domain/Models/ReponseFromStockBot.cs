namespace StockChatBot.Dto
{
    public class ResponseFromStockBotDto
    {
        public ResponseFromStockBotDto(){}
        public string BotName { get; set; } = "Stock Bot";
        public string? Message { get; set; }
        public int ChatRoomId { get; set; }
        public string? ChatRoomName { get; set; }
        public string? SenderConnectionId { get; set; }
        public string? RecieverConnectionId { get; set; }
        public bool IsRoomMessage { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = String.Empty;   
    }
}
