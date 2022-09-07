using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using ChatApp.Interfaces;
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

        public async Task CreateRoomMessage(int roomId, RoomMessage roomMessage)
        {
            ChatRoom? foundroom = await _chatRoomRepository.GetByRoomIdAsync(roomId);
            
            if (foundroom is not null && foundroom.Messages is not null)
            {
                foundroom.Messages.Add(roomMessage);

                await _chatRoomRepository.Add(foundroom);
            }
        }

        public Task<List<RoomMessage>?> GetRoomMessagesByIdAsync(int roomId, int load = 50)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomMessage>?> GetRoomMessagesByRoomIdAsync(int roomId, int load = 50)
        {
            ChatRoom? foundroom = await _chatRoomRepository.GetByRoomIdAsync(roomId);
             
            if (foundroom is not null)
            {
                List<RoomMessage>? foundMessages = await _roomMessageRespository.GetOrderedMessageWithLimitAsync(foundroom);
                return foundMessages;
            }            
            return null;
        }
            
    }
}
