namespace ChatApp.Services
{
    public static class MessageActionService
    {
        public static bool IsBotMessage(string message)
        {
            var stockFormat = "/";
            return message.StartsWith(stockFormat);
        }

    }
}
