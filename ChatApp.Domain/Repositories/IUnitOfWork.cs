using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Repositories
{
    internal interface IUnitOfWork
    {
        IChatRoomRepository ChatRoom { get; }
        IRoomMessageRepository RoomMessage { get; }

        void Complete();
    }
}
