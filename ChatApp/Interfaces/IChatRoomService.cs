using chat_application.Models;
using System.Linq.Expressions;

namespace ChatApp.Interfaces
{
    public interface IChatRoomService
    {
        public Task<List<ChatRoom>?> GetAllChatRoomsAsync();
        public Task<string?> UpdateOnlineUserChatRoom(int chatRoomId, string userName);

    }
}
