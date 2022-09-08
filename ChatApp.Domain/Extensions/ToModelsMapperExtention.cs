using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Extensions
{
    public static class ToModelsMapperExtention
    {
       
        public static List<Models.RoomMessage>? ToRoomMessages(this List<Entities.RoomMessageEntity> roomMessages)
        {
            return roomMessages.Select(x => { return x.ToRoomMessage(); }).ToList();
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


        public static List<ChatRoom> ToChatRooms(this IEnumerable<ChatRoomEntity> entities)
        {
            return entities.Select(entity =>
            {
                return entity.ToChatRoom();
            }
            ).ToList();
        }


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
    }
}
