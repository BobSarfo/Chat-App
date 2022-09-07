using ChatApp.Domain.Models;
using ChatApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Extensions
{
    public static class MessageMapperExtention
    {


        
        public static List<RoomMessage>? ToRoomMessages(this List<RoomMessageEntity> entity)
        {

            List<RoomMessage> roomMessages = entity.Select(x =>
            {
                return x.ToRoomMessage();
            }).ToList();

            return roomMessages;

        }

        public static RoomMessage ToRoomMessage(this RoomMessageEntity roomMessageEntity)
        {
            return new RoomMessage
            {
                ChatRoomId = roomMessageEntity.ChatRoomId,
                Id = roomMessageEntity.Id,
                IsStockCode = roomMessageEntity.IsStockCode,
                Message = roomMessageEntity.Message,
                SenderId = roomMessageEntity.SenderId,
                SenderUsername = roomMessageEntity.SenderUsername,
                Timestamp = roomMessageEntity.Timestamp,
            };
        }


        public static RoomMessageEntity ToRoomMessageEntity(this RoomMessage model)
        {
            return new RoomMessageEntity
            {
                Message = model.Message,
                ChatRoomId = model.ChatRoomId,
                IsStockCode = model.IsStockCode,
                SenderId = model.SenderId,
                SenderUsername = model.SenderUsername,
                Timestamp = model.Timestamp,
            };

        }

        public static List<RoomMessageEntity> ToRoomMessagesEntity(this List<RoomMessage> roomMessages)
        {
            return roomMessages.Select(x => x.ToRoomMessageEntity()).ToList();

        }
    }
}
