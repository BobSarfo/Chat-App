using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Repositories;

public interface IChatRoomRepository : IBaseRepository<ChatRoomEntity> {

    public Task AddMessage(int roomId, Entities.RoomMessageEntity roomMessage);

    public Task AddMessage(string roomName, Entities.RoomMessageEntity roomMessage);
}