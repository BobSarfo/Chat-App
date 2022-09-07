using ChatApp.Data.Contexts;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Repositories;

namespace ChatApp.Infrastructure.Repositories;

public class ChatRoomRepository : BaseRepository<ChatRoom>, IChatRoomRepository
{
    public ChatRoomRepository(ChatAppDbContext context) : base(context)
    {
    }

    public async Task<ChatRoom?> GetByRoomNameAsync(string roomName)
    {
        var roomEntity = await Task.FromResult(Find(entity => entity.RoomName == roomName).FirstOrDefault());
        return roomEntity?.ToChatRoom();
    }

    public async Task<ChatRoom> Add(ChatRoom input)
    {
        var entity = await SaveAsync(input.FromChatRoom());
        return entity.ToChatRoom();
    }

    public async Task<List<ChatRoom>> GetRooms()
    {
        var entities = await Task.FromResult(GetAll());
        return entities.ToChatRooms();
    }
}