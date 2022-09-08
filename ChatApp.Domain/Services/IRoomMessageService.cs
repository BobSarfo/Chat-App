using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Services
{
    public interface IRoomMessageService
    {
      
        public Task<List<RoomMessage>?> GetRecentRoomMessage(int roomId, int load = 50);
        public Task CreateRoomMessage(int roomId, RoomMessage roomMessage);

    }
}
