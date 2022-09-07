using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Services
{
    public interface IChatRoomService
    {
        Task<List<ChatRoom>> GetAllRooms();
    }
}
