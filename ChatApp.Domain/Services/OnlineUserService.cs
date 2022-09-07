using ChatApp.Domain.Extensions;
using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;

namespace ChatApp.Domain.Services
{
    public class OnlineUserService : IOnlineUserService
    {
        private readonly IDictionary<string, ConnectedUser> _connections;
        private readonly IChatRoomRepository _chatRoomRepository;

        public OnlineUserService(IDictionary<string, ConnectedUser> connections, IChatRoomRepository chatRoomRepository)
        {
            _connections = connections;
            _chatRoomRepository = chatRoomRepository;
        }
        public async Task<string?> UpdateChatRoom(int chatRoomId, string userName)
        {
            var chatRooms = await _chatRoomRepository.GetRooms();

            var foundRoom = chatRooms?.FirstOrDefault(x => x.Id == chatRoomId);
            if (foundRoom is not null && _connections.Count > 0)
            {
                var userHubConnectionId = _connections.GetConnectionStringByUserName(userName);
                if (userHubConnectionId is not null && _connections.TryGetValue(userHubConnectionId, out var connectedUser))
                {
                    connectedUser.SelectedRoomName = foundRoom.RoomName;
                    _connections[userHubConnectionId] = connectedUser;
                }

            }

            return foundRoom?.RoomName;
        }

    }
}
