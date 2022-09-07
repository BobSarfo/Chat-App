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
        public static ChatRoom ToRoomMessage(this ChatRoomEntity entity)
        {
            return new ChatRoom
            {
                Id = entity.Id,
                DateCreated = entity.DateCreated,
                Messages = entity.Messages.ToRoomMessages() ?? new List<RoomMessage>(),
                RoomName = entity.RoomName,
            };

        }

        public static ChatRoomEntity ToRoomMessageEntity(this ChatRoom  entity)
        {
            return new ChatRoom
            {
                DateCreated = entity.DateCreated,
                Messages = entity.Messages.ToMessageEntity(),
                RoomName = entity.RoomName,
            };
        }


        public static List<RoomMessage>? ToRoomMessages(this List<RoomMessageEntity> entity)
        {          

            List<RoomMessage> roomMessages = entity.Select(x =>
            {
                return
                new RoomMessage
                {
                    ChatRoomId = x.ChatRoomId,
                    Id = x.Id,
                    IsStockCode = x.IsStockCode,
                    Message = x.Message,
                    SenderId = x.SenderId,
                    SenderUsername = x.SenderUsername,
                    Timestamp = x.Timestamp,

                };
            }).ToList();

            return roomMessages;

        }


        public static List<RoomMessageEntity>? ToMessageEntity(this List<RoomMessage> entity)
        {

            List<RoomMessage> roomMessages = entity.Select(x =>
            {
                return
                new RoomMessageEntity
                {
                    ChatRoomId = x.ChatRoomId,
                    IsStockCode = x.IsStockCode,
                    Message = x.Message,
                    SenderId = x.SenderId,
                    SenderUsername = x.SenderUsername,
                    Timestamp = x.Timestamp,
                     
                };
            }).ToList();

            return roomMessages;

        }
    }
}
