using ChatApp.Domain.Entities;

namespace ChatApp.Interfaces
{
    public interface IRoomMessageService
    {

        public Task<List<RoomMessage?>?> GetRoomMessagesByIdAsync(int roomId, int load = 50);
        public Task<List<RoomMessage?>?> GetRoomMessagesByIdAsync(int roomId, int load = 50);
        public Task CreateRoomMessage(int roomId, RoomMessage roomMessage);



        public Task CreateRoomMessage(int roomId, RoomMessage roomMessage);
    }
}
