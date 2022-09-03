using ChatApp.Interfaces;

namespace ChatApp.Data.Repositories
{
    public class RoomMessageRepository : IRoomMessageRepository
    {
        private readonly ApplicationDbContext _db;
        public RoomMessageRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
