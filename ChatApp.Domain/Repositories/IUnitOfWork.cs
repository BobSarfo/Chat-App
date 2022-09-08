using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IChatRoomRepository ChatRoom { get; }
        IRoomMessageRepository RoomMessage { get; }

        public Task<int> Complete();
    }
}
