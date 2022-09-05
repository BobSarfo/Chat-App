using Newtonsoft.Json;
using Plain.RabbitMQ;

namespace ChatApp.Services
{
    public class ChatListner : BackgroundService
    {
        private readonly ISubscriber subscriber;
        private readonly ILogger<ChatListner> _logger;

        public ChatListner(ISubscriber subscriber,ILogger<ChatListner> logger)
        {
            this.subscriber = subscriber; _logger = logger;
            ;
        }


        private bool Subscribe(string message, IDictionary<string, object> header)
        {
            _logger.LogInformation(message);


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
