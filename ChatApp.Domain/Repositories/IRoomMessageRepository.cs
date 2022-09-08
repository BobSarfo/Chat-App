using ChatApp.Domain.Models;

namespace ChatApp.Domain.Repositories
{
    public interface IRoomMessageRepository
    {
        public Task<List<RoomMessage>?> GetRecentMessages(ChatRoom room, int load = 50);
    }
}
