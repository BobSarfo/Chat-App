using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Extensions
{
    public static class ToEntitiesMapperExtention
    {      

      

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

           
        public static ChatRoomEntity ToChatRoomEntity(this ChatRoom entity)
        {
            return new ChatRoomEntity()
            {
                RoomName = entity.RoomName,
                Messages = entity.Messages is null ? new List<Entities.RoomMessageEntity>() : entity.Messages.ToRoomMessageEntities()
            };
        }
    }
}
