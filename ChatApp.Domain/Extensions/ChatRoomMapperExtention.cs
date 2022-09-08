using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;

namespace ChatApp.Domain.Extensions
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
            return new ChatRoomEntity()
            {
                RoomName = entity.RoomName,
                Messages = entity.Messages is null ? new List<RoomMessageEntity>() : entity.Messages.ToRoomMessageEntities()
            };
        }
        public static List<ChatRoom>? ToChatRooms(this List<ChatRoomEntity>? chatRooms)
        {
            return chatRooms is null ? null : chatRooms.Select(x => x.ToChatRoom()).ToList();
        }

    }
}
