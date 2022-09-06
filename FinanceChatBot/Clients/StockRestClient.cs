using StockChatBot.Models;
using StockChatBot.Utils;

namespace StockChatBot.Clients;

public class StockRestClient : IStockRestClient
{
    private readonly HttpClient _client;
    private static readonly Dictionary<string, List<Stock>> StockInMemory = new();
    //implement cache expiry

    public StockRestClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Stock>> GetStocksAsync(string stockName)
    {
        var cacheList = StockInMemory.GetValueOrDefault(stockName);
        if (cacheList is not null) return cacheList;
        var uri = $"https://stooq.com/q/l/?s={stockName}&f=sd2t2ohlcv&h&e=csv";
        using var response = await _client.GetAsync(uri);
        await using var stream = await response.Content.ReadAsStreamAsync();
        var stocks = ParseStockCsv.GetStocks(stream);
        StockInMemory.Add(stockName, stocks);
        return stocks;
    }
}