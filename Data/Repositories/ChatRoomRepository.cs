using ChatApp.Interfaces;

namespace ChatApp.Data.Repositories
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public ChatRoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
