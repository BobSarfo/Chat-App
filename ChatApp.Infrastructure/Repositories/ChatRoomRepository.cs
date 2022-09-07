using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Contexts;
using ChatApp.Infrastructure.Entities;
using ChatApp.Infrastructure.Extensions;

namespace ChatApp.Infrastructure.Repositories;

public class ChatRoomRepository : BaseRepository<ChatRoomEntity>, IChatRoomRepository
{
    public ChatRoomRepository(ChatAppDbContext context) : base(context)
    {
    }

    public async Task<ChatRoom?> GetByRoomNameAsync(string roomName)
    {
        var roomEntity = await Task.FromResult(Find(entity => entity.RoomName == roomName).FirstOrDefault());
        
        return roomEntity is null? null:roomEntity.ToChatRoom();
    }
    public async Task<ChatRoom?> GetByRoomIdAsync(int roomId)
    {
        var roomEntity = await Task.FromResult(Find(entity => entity.Id == roomId).FirstOrDefault());
        return roomEntity is null ? null : roomEntity.ToChatRoom();

    }

    public async Task<ChatRoom> Add(ChatRoom input)
    {
        var entity = await SaveAsync(input.ToChatRoomEntity());
        return entity.ToChatRoom();
    }

    public async Task<List<ChatRoom>?> GetRooms()
    {
        var entities = await Task.FromResult(GetAll().ToList());
        return entities.ToChatRooms();
    }

   
}