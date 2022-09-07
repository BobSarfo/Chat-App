using StockChatBot.Clients;
using StockChatBot.Dto;
using StockChatBot.Models;

namespace StockChatBot.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRestClient _stockRestClient;
        private readonly ILogger<StockService> _logger;

        public StockService(IStockRestClient stockRestClient,ILogger<StockService> logger)
        {
            _stockRestClient = stockRestClient;
            _logger = logger;
        }

        public async Task<List<Stock>?> GetStockByCodeAsync(string? stockCode)
        {
            if (stockCode is null)
            {
                return null;
            }
            return await _stockRestClient.GetStocksAsync(stockCode);
        }


        public async Task<ResponseFromStockBotDto> BotRequestHandler(RequestToStockBotDto request)
        {
            var result = new ResponseFromStockBotDto
            {
                ChatRoomName = request.ChatRoomName,
                ChatRoomId = request.ChatRoomId,
                RecieverConnectionId = request.RecieverConnectionId,
                SenderConnectionId = request.SenderConnectionId,
            };

            if (request.Message is null)
            {
                result.ErrorMessage = "No Stock Code";
                result.IsSuccess = false;

                return result;
            }

            if(!request.Message.StartsWith("/stock="))
            {
                result.ErrorMessage = "Error in code sent, command start with: /stock= .Try again";
                result.IsSuccess = false;

                return result;
            }

            List<Stock>? stocks = new();

            try
            {
                stocks = await GetStockByCodeAsync(request.Message);
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Bot Server Error Occurred Getting Stock Data";
                result.IsSuccess = false;
                _logger.LogError(ex,ex.InnerException is null ? "Error Occured Reading Fetching Data" : ex.InnerException.Message);
                return result;
            }

            if (stocks is null)
            {
                result.ErrorMessage = "No Information Found";
                result.IsSuccess = false;
                _logger.LogError(result.ErrorMessage);
                return result;

            }

            var stock = stocks.FirstOrDefault();

            if (stock is null)
            {
                result.ErrorMessage = "No Information Found";
                result.IsSuccess = false;
                _logger.LogError(result.ErrorMessage);
                return result;
            }

            if (stock.Close.Equals("N/D", StringComparison.CurrentCultureIgnoreCase))
            {
                result.ErrorMessage = "No Stocks Information Found: Invalid Stock Code";
                result.IsSuccess = false;
                _logger.LogError(result.ErrorMessage);
                return result;
            }
           
            var botMessage = $"{stock.Symbol} quote is ${stock.Open} per share";

            result.Message = botMessage;
            result.IsSuccess = true;

            return result;
        }
    }
}
