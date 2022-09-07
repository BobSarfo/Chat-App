namespace ChatApp.Domain.Extensions
{
    public static class MessageActionService
    {
        public static bool IsBotMessage(this string message)
        {
            var stockFormat = "/stock=";
            return message.StartsWith(stockFormat);
        }

        public static string GetStockCodeFromMessage(this string message)
        {
            return message.Split("=")[1];
        }
    }
}
