using Newtonsoft.Json;
using Plain.RabbitMQ;
using StockChatBot.Dto;
using System.Text.Json;

namespace StockChatBot.Services
{
    public class StockBot : BackgroundService
    {
        private readonly ISubscriber subscriber;
        private readonly IPublisher _publisher;
        private readonly ILogger<StockBot> _logger;
        private readonly IStockService _stockService;

        public StockBot (ISubscriber subscriber,
            IPublisher publisher, ILogger<StockBot> logger, IStockService stockService)
        {
            this.subscriber = subscriber;
            _publisher = publisher;
            _logger = logger;
            _stockService = stockService;
        }


        private bool Subscribe(string dto, IDictionary<string, object> header)
        {
            var data = JsonConvert.DeserializeObject<RequestToStockBotDto>(dto);
           
            _logger.LogInformation("Incoming request code: " + data.Message);
            //Implement the stock reading send
            var reponse  = _stockService.BotRequestHandler(data).Result;

            var response = JsonConvert.SerializeObject(reponse);

            _publisher.Publish(response, "stockbotmessage", null);
          

            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            subscriber.Subscribe(Subscribe);
            return Task.CompletedTask;
        }
    }
}
