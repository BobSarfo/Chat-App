using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Repositories;

public interface IChatRoomRepository {

    Task<ChatRoom?> GetByRoomNameAsync(string secret);
    Task<ChatRoom> Add(ChatRoom input);
    Task<List<ChatRoom>> GetRooms();
}