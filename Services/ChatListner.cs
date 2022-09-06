using chat_application.Models;
using ChatApp.Hubs;
using ChatApp.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using StockChatBot.Dto;

namespace ChatApp.Services
{
    public class ChatListner : BackgroundService
    {
        private readonly ISubscriber _subscriber;
        private readonly IRoomMessageService _roomMessageService;
        private readonly IHubContext<MessageHub> _messageHub;

        public ChatListner(ISubscriber subscriber, IRoomMessageService roomMessageService,
         IHubContext<MessageHub> messageHub)
        {
            _subscriber = subscriber;
            _roomMessageService = roomMessageService;
            _messageHub = messageHub;
        }


        private bool Subscribe(string dto, IDictionary<string, object> header)
        {
            var data = JsonConvert.DeserializeObject<ResponseFromStockBotDto>(dto);


            var roomMessage = new RoomMessage
            {
                Message = data.Message,
                IsStockCode = true,
                ChatRoomId = data.ChatRoomId,
                SenderUsername = data.BotName,
                SenderId = -1, 
                Timestamp = DateTime.UtcNow
            };

            if (data.IsSuccess)
            {
                _roomMessageService.CreateRoomMessage(roomMessage.ChatRoomId, roomMessage);

                _messageHub.Clients.Groups(data.ChatRoomName).SendAsync("ReceiveGroupMessage", new
                {
                    message = data.Message,
                    username = data.BotName,
                    timeStamp = DateTime.UtcNow.ToString("g")
                });

            }

            //handle errors and loggings
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(Subscribe);
            return Task.CompletedTask;
        }
    }
}
