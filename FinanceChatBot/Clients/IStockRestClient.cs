using StockChatBot.Models;

namespace StockChatBot.Clients;

public interface IStockRestClient
{
    Task<List<Stock>> GetStocksAsync(string stockName);
}