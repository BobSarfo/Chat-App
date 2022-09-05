using chat_application.Models;
using ChatApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly ApplicationDbContext _db;
        public PrivateMessageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<PrivateMessage>> GetMessagesOfUserAndReciepientAsync(int userId, int receiverId, int load = 50)
        {
            var foundUserMessages = await _db.PrivateMessage
                                        .Where(x => x.SenderId == userId && x.ReceiverId == receiverId)
                                        .Take(load)
                                        .OrderByDescending(x => x.Timestamp).ToListAsync();

            return foundUserMessages;

        }

        public void AddMessagesOfUserAndReciepientAsync(int userId, int receiverId, string message, bool isStockCode = false) 
        {
            var chatMessage = new PrivateMessage 
            {
                 SenderId = userId,
                 ReceiverId = receiverId,
            };

        }
        

    }
}
