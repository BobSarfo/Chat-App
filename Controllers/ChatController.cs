using chat_application.Extensions;
using chat_application.Models;
using ChatApp.Dtos;
using ChatApp.Extensions;
using ChatApp.Hubs;
using ChatApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IRoomMessageService _roomMessageService;
        private readonly IHubContext<MessageHub> _messageHub;
        private readonly IDictionary<string, ConnectedUserDto> _connections;

        public ChatController(IChatRoomService chatRoomService,
            IRoomMessageService roomMessageService,
            IHubContext<MessageHub> messageHub,
            IDictionary<string, ConnectedUserDto> connections)
        {
            _chatRoomService = chatRoomService;
            _roomMessageService = roomMessageService;
            _messageHub = messageHub;
            _connections = connections;
        }

        public async Task<IActionResult> ChatRoom()
        {
            List<ChatRoom> namesOfRooms = new();
            List<RoomMessage?> roomMessages = new();
            var data = new ChatRoomDto { RoomNames = namesOfRooms, RoomMessages = roomMessages };
            if (User.Identity is null)
            {
                return View(data);
            }
            else
            {
                var defaultSeededRoomId = 1;
                var chatRooms = await _chatRoomService.GetAllChatRoomsAsync();

                var foundRoomMessages = await _roomMessageService.GetRoomMessagesByIdAsync(defaultSeededRoomId);

                if (foundRoomMessages is not null)
                {
                    roomMessages = foundRoomMessages;
                    data.RoomMessages = roomMessages;
                }

                if (chatRooms is not null)
                {
                    namesOfRooms = chatRooms;
                    data.RoomNames = namesOfRooms;
                }
            }

            return View(data);
        }

        public async Task<IActionResult> PrivateChat()
        {

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateGroupMessage([FromBody] CreateRoomMessageDto createRoomMessage)
        {
            var all = _connections;
            var connStr = _connections.GetConnectionStringByUserName(User.GetUsername());



            var roomMessage = new RoomMessage
            {
                Message = createRoomMessage.Message,
                IsStockCode = true,
                ChatRoomId = createRoomMessage.RoomId,
            };


            if (connStr is not null && _connections.TryGetValue(connStr, out ConnectedUserDto connectedUser))
            {
                roomMessage.SenderId = connectedUser.UserId;
                roomMessage.SenderUsername = connectedUser.UserName;

                await _roomMessageService.CreateRoomMessage(createRoomMessage.RoomId, roomMessage);
                await _messageHub.Clients.Group(connectedUser.SelectedRoomName)
                    .SendAsync("ReceiveGroupMessage", new {
                        message =  roomMessage.Message,
                        username = roomMessage.SenderUsername,
                        timeStamp = roomMessage.Timestamp.ToString("g")
                    });
            }

            return Json(new { status = 1, message = "success" });

        }

    }
}
