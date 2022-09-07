using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChatApp.Domain.Services
{
    public class OnlineUserService
    {
        public OnlineUserService()
        {

        }
        public async Task<string?> UpdateChatRoom(int chatRoomId, string userName)
        {
            //call repository
            var chatRooms = await GetAllChatRoomsAsync();

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
