using CsvHelper;
using StockChatBot.Models;
using System.Globalization;

namespace StockChatBot.Utils
{
    public class ParseStockCsv    {

        public static List<Stock> GetStocks(Stream content)
        {
            using var reader = new StreamReader(content);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Stock>().ToList();

        }
    }
}
