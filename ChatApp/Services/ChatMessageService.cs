namespace ChatApp.Services
{
    public static class ChatMessageService
    {
        public static bool IsBotMessage(string message)
        {
            var stockFormat = "/stock=";
            return message.StartsWith(stockFormat);
        }

        public static string GetStockCodeFromMessage(string message) 
        {
            return message.Split("=")[1];
        }
    }
}
