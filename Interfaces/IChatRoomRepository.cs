using chat_application.Models;
using System.Linq.Expressions;

namespace ChatApp.Interfaces
{
    public interface IChatRoomRepository
    {
        public Task<bool> AddChatRoomAsync(string chatRoomName);
        public Task<bool> RemoveChatRoomAsync(string chatRoomName);
        public Task<List<ChatRoom>?> GetAllChatRoomsAsync();
        
        public Task<List<RoomMessage?>?> GetMessagesFromRoomIdAsync(int roomId, int load=50);

    }
}
