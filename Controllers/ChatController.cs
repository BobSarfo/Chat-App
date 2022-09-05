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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<MessageHub> _messageHub;
        private readonly IDictionary<string, ConnectedUserDto> _connections;

        public ChatController(IUnitOfWork unitOfWork,
            IHubContext<MessageHub> messageHub,
            IDictionary<string, ConnectedUserDto> connections)
        {
            _unitOfWork = unitOfWork;
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
                var chatRooms = await _unitOfWork.ChatRoomRepository.GetAllChatRoomsAsync();
                //change this function to meessage repository
                var foundRoomMessages = await _unitOfWork.ChatRoomRepository.GetMessagesFromRoomIdAsync(1);

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
        public JsonResult CreateGroupMessage([FromBody] CreateRoomMessageDto createRoomMessage)
        {
            var all = _connections;
            var connStr = _connections.GetConnectionStringByUserName(User.GetUsername());



            var message = new RoomMessage
            {
                Message = createRoomMessage.Message,              
                 IsStockCode = true,
            };

            if (connStr is not null && _connections.TryGetValue(connStr, out ConnectedUserDto connectedUser))
            {
                message.SenderId = connectedUser.UserId;
                message.SenderUsername = connectedUser.UserName;

                message.ChatRoomId = connectedUser.SelectedRoomName ,
                _messageHub.Clients.Group(createRoomMessage.RoomName)
                    .SendAsync("ReceiveGroupMessage", createRoomMessage.Message, connectedUser);
            }

            //return JsonResult();
            return Json(new { status = 1, message = "success" });

        }

    }
}
