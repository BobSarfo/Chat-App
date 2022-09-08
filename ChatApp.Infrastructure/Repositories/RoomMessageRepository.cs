using ChatApp.Domain.Entities;
using ChatApp.Domain.Extensions;
using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class RoomMessageRepository :  BaseRepository<Domain.Entities.RoomMessageEntity> , IRoomMessageRepository
{
    private readonly ChatAppDbContext _db;

    public RoomMessageRepository(ChatAppDbContext context) : base(context)
    {
        _db = context;
    }

    public async Task<List<RoomMessageEntity>?> GetRecentMessages(int roomId, int load = 50)
    {
        return await _db.RoomMessages.Where(x => x.ChatRoomId == roomId)
            .OrderByDescending(x => x.Timestamp).Take(load).ToListAsync();
        
    }

    public async Task<List<RoomMessageEntity>?> GetRecentMessages(string roomName, int load = 50)
    {
        return await _db.RoomMessages.Include(x=>x.ChatRoom.RoomName.ToLower().Equals(roomName.ToLower()))
            .OrderByDescending(x=>x.Timestamp).Take(load).ToListAsync();
    }



}