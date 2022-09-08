using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Contexts;
using ChatApp.Infrastructure.Entities;
using ChatApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Repositories;

public class RoomMessageRepository : BaseRepository<RoomMessageEntity>, IRoomMessageRepository
{
    public RoomMessageRepository(ChatAppDbContext context) : base(context)
    {
    }

    public async Task<RoomMessage> SaveMessageAsync(RoomMessage chatMessage)
    {
        var entity = await SaveAsync(chatMessage.ToRoomMessageEntity());
        return entity.ToRoomMessage();
    }

    public async Task<List<RoomMessage>?> GetRecentMessages(ChatRoom room,int load =50 )
    {
         var foundEntities= await _context.RoomMessages.Where(x => x.ChatRoomId == room.Id).Take(load).ToListAsync();

        return foundEntities.ToRoomMessages();
    }


    public async Task<List<RoomMessage>?> GetByRoom(ChatRoom chatRoom)
    {
        var entity = await Task.FromResult(FindAsync(x => x.Id == chatRoom.Id).ToList());
        return entity.ToRoomMessages();
    }




}