using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Services
{
    public interface IRoomMessageService
    {
        public Task<List<RoomMessageEntity>?> GetRoomMessagesByIdAsync(int roomId, int load = 50);
        public Task CreateRoomMessage(int roomId, RoomMessageEntity roomMessage);

    }
}
