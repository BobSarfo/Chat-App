using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatApp.Domain.Repositories;
using System.Threading.Tasks;
using ChatApp.Infrastructure.Contexts;

namespace ChatApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatAppDbContext _db;

        public UnitOfWork(ChatAppDbContext context)
        {
            _db = context;

        }
        public IChatRoomRepository ChatRoom =>  new ChatRoomRepository(_db);

        public IRoomMessageRepository RoomMessage =>  new RoomMessageRepository(_db);

        public Task<int> CompleteAsync()
        {
            return _db.SaveChangesAsync();
        }
         
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
