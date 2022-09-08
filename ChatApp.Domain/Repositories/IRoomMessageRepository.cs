using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Repositories
{
    public interface IRoomMessageRepository : IBaseRepository<Entities.RoomMessageEntity>
    {
        public Task<List<Entities.RoomMessageEntity>?> GetRecentMessages(int roomId, int load = 50);
    }
}
