using ChatApp.Interfaces;

namespace ChatApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public IUserRepository UserRepository => new UserRepository(_db);

        public IPrivateMessageRepository PrivateMessageRepository => new PrivateMessageRepository(_db);

        public IRoomMessageRepository RoomMessageRepository =>  new RoomMessageRepository(_db);

        public IChatRoomRepository ChatRoomRepository => new ChatRoomRepository(_db);

        public async Task<bool> Complete()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            _db.ChangeTracker.DetectChanges();
            var changes = _db.ChangeTracker.HasChanges();

            return changes;
        }
    }
}
