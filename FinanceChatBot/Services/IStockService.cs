using StockChatBot.Dto;
using StockChatBot.Models;

namespace StockChatBot.Services
{
    public interface IStockService
    {
        Task<List<Stock>?> GetStockByCodeAsync(string stockCode);
        Task<ResponseFromStockBotDto> BotRequestHandler(RequestToStockBotDto request);
    }
}
