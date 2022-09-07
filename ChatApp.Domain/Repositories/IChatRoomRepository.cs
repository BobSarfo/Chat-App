using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Repositories;

public interface IChatRoomRepository {

    Task<ChatRoom?> GetByRoomNameAsync(string roomName);
    Task<ChatRoom> Add(ChatRoom input);
    Task<List<ChatRoom>> GetRooms();
}