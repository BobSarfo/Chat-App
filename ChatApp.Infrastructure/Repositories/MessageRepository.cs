using ChatApp.Domain.Models;
using ChatApp.Infrastructure.Contexts;
using ChatApp.Infrastructure.Entities;
using ChatApp.Infrastructure.Extensions;
using ChatApp.Interfaces;
using System;

namespace ChatApp.Infrastructure.Repositories;

public class MessageRepository : BaseRepository<RoomMessageEntity>, IRoomMessageRepository
{
    public MessageRepository(ChatAppDbContext context) : base(context)
    {
    }

    public async Task<RoomMessage> SaveMessageAsync(RoomMessage chatMessage)
    {
        var entity = await SaveAsync(chatMessage.ToRoomMessageEntity());
        return entity.ToRoomMessage();
    }

    
}