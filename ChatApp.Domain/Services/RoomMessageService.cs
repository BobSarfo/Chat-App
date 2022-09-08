using ChatApp.Domain.Entities;
using ChatApp.Domain.Extensions;
using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using System.Collections.Generic;

namespace ChatApp.Domain.Services
{
    public class RoomMessageService : IRoomMessageService
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly IRoomMessageRepository _roomMessageRespository;
        private readonly IUnitOfWork _uow;

        public RoomMessageService(IChatRoomRepository chatRoomRepository,
            IRoomMessageRepository roomMessageRespository,
            IUnitOfWork uow)
        {
            _chatRoomRepository = chatRoomRepository;
            _roomMessageRespository = roomMessageRespository;
            _uow = uow;
        }

        public async Task CreateRoomMessage(int roomId, RoomMessage roomMessage)
        {
            _chatRoomRepository.AddMessage(roomId, roomMessage.ToRoomMessageEntity());
            await _uow.CompleteAsync();
        }

    

        public async Task<List<RoomMessage>?> GetRecentRoomMessage(int roomId, int load = 50)
        {
            var entities = (await _roomMessageRespository.GetRecentMessages(roomId, load));
            if (entities is not  null)
                return entities.ToRoomMessages();

            return null;
        }     
            
    }
}
