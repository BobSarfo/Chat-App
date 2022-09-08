using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Extensions
{
    public static class MessageMapperExtention
    {
        public static List<Models.RoomMessage>? ToRoomMessages(this List<Entities.RoomMessageEntity> entity)
        {

            List<Models.RoomMessage> roomMessages = entity.Select(x =>
            {
                return x.ToRoomMessage();
            }).ToList();

            return roomMessages;

        }

        public static Models.RoomMessage ToRoomMessage(this Entities.RoomMessageEntity roomMessageEntity)
        {
            return new Models.RoomMessage
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


        public static Entities.RoomMessageEntity ToRoomMessageEntity(this Models.RoomMessage model)
        {
            return new Entities.RoomMessageEntity
            {
                Message = model.Message,
                ChatRoomId = model.ChatRoomId,
                IsStockCode = model.IsStockCode,
                SenderId = model.SenderId,
                SenderUsername = model.SenderUsername,
                Timestamp = model.Timestamp,
            };

        }

        public static List<Entities.RoomMessageEntity> ToRoomMessageEntities(this List<Models.RoomMessage> roomMessages)
        {
            return roomMessages.Select(x => x.ToRoomMessageEntity()).ToList();

        }
    }
}
