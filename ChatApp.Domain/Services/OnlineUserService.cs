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
        public async Task<string?> UpdateUserChatRoom(int chatRoomId, string userName)
        {
            var foundRoom = (await _chatRoomRepository.FindSingleAsync(x=>x.Id==chatRoomId)).ToChatRoom();

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
