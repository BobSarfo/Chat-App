using ChatApp.Domain.Entities;

namespace ChatApp.Interfaces
{
    public interface IRoomMessageReposity
    {

        public Task CreateRoomMessage(int roomId, RoomMessage roomMessage);
    }
}
