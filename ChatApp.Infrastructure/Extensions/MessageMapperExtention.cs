using ChatApp.Domain.Entities;
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
        public static RoomMessage ToRoomMessage(this RoomMessageEntity entity)
        {
            return new RoomMessage
            {
                Id = entity.Id,
                Message = entity.Message,
                ChatRoomId = entity.ChatRoomId,
                IsStockCode = entity.IsStockCode,
                SenderId = entity.SenderId,
                SenderUsername = entity.SenderUsername,
                Timestamp = entity.Timestamp,
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
    }
}
