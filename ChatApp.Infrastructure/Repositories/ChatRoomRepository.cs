using ChatApp.Domain.Entities;
using ChatApp.Domain.Extensions;
using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class ChatRoomRepository : BaseRepository<ChatRoomEntity>, IChatRoomRepository
{
    private readonly ChatAppDbContext _db;

    public ChatRoomRepository(ChatAppDbContext context) : base(context)
    {
        _db = context;
    }


    public async Task AddMessage(int roomId, Domain.Entities.RoomMessageEntity roomMessage)
    {
        var foundRoom = await GetAsync(roomId);
        if (foundRoom is not null)
        {

            foundRoom.Messages.Add(roomMessage);
            await AddAsync(foundRoom);
        }

    }
 

    public async Task AddMessage(string roomName, Domain.Entities.RoomMessageEntity roomMessage)
    {
        var foundRoom = await FindSingleAsync(x=>x.RoomName.ToLower().Equals(roomName.ToLower()));
        if (foundRoom is not null)
        {

            foundRoom.Messages.Add(roomMessage);
            await AddAsync(foundRoom);
        }
    }


}