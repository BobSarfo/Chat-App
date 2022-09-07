using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Extensions
{
    public static class ChatRoomMapperExtention
    {
        public static ChatRoom ToChatRoom(this ChatRoomEntity entity)
        {
            return new ChatRoom
            {
                Id = entity.Id,
                DateCreated = entity.DateCreated,
                Messages = entity.Messages == null ? null : entity.Messages.ToRoomMessages(),
                RoomName = entity.RoomName,
            };

        }

        public static ChatRoomEntity ToChatRoomEntity(this ChatRoom entity)
        {
            return new ChatRoomEntity(entity.RoomName)
            {
                Messages = entity.Messages is null ? new List<RoomMessageEntity>() : entity.Messages.ToRoomMessagesEntity(),              
            };
        }
        public static List<ChatRoom>? ToChatRooms(this List<ChatRoomEntity>? chatRooms)
        {
            return chatRooms is null ? null : chatRooms.Select(x => x.ToChatRoom()).ToList();
        }

    }
}
