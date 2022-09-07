using ChatApp.Domain.Models;

namespace ChatApp.Interfaces
{
    public interface IRoomMessageRepository
    {
        public Task<List<RoomMessage>?> GetOrderedMessageWithLimitAsync(ChatRoom room, int load = 50);
    }
}
