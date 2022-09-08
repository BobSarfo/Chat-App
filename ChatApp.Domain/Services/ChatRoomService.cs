using ChatApp.Domain.Models;
using ChatApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Services
{
    public class ChatRoomService: IChatRoomService
    {
        private readonly IChatRoomRepository _chatRoomRepository;

        public ChatRoomService(IChatRoomRepository chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public async Task<List<ChatRoom>> GetAllRooms()
        {
            return (await _chatRoomRepository.GetAllAsync()).ToChatRooms();
        }
    }
}
