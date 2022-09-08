using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using System.Collections.Generic;

namespace ChatApp.Domain.Services
{
    public class RoomMessageService : IRoomMessageService
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly IRoomMessageRepository _roomMessageRespository;

        public RoomMessageService(IChatRoomRepository chatRoomRepository,
            IRoomMessageRepository roomMessageRespository)
        {
            _chatRoomRepository = chatRoomRepository;
            _roomMessageRespository = roomMessageRespository;
        }

        public async Task CreateRoomMessage(int roomId, Entities.RoomMessageEntity roomMessage)
        {
            ChatRoom? foundroom = await _chatRoomRepository.GetByRoomIdAsync(roomId);
            
            if (foundroom is not null && foundroom.Messages is not null)
            {
                foundroom.Messages.Add(roomMessage);

                await _chatRoomRepository.Save(foundroom);
            }
        }

        public async Task<List<Entities.RoomMessageEntity?>?> GetRoomMessagesByIdAsync(int roomId, int load = 50)
        {
            ChatRoom? foundroom = await _chatRoomRepository.GetByRoomIdAsync(roomId);

            if (foundroom is not null)
            {
                List<Entities.RoomMessageEntity>? foundMessages = await _roomMessageRespository.GetRecentMessages(foundroom);
                return foundMessages;
            }
            return null;
        }     
            
    }
}
