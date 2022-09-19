using chat_application.Models;
using System.Linq.Expressions;

namespace ChatApp.Interfaces
{
    public interface IChatRoomService
    {
        public Task<bool> AddChatRoomAsync(string chatRoomName);
        public Task<bool> RemoveChatRoomAsync(string chatRoomName);
        public Task<List<ChatRoom>?> GetAllChatRoomsAsync();
        public Task<string?> UpdateOnlineUserChatRoom(int chatRoomId, int userName);

    }
}
