using ChatApp.Interfaces;

namespace ChatApp.Data.Repositories
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly ApplicationDbContext _db;
        public PrivateMessageRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
