using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.Controllers.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly DatabaseContext _context;
        public MessagesService(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<List<Message>> GetSentMessages(string userId, string receiverId)
        {
            var sentMessages = await _context.Messages.Where(k => k.SenderId == userId && k.ReceiverId == receiverId).ToListAsync();

            return sentMessages;
        }

        public async Task<List<Message>> GetReceivedMessages(string userId, string senderId)
        {
            var sentMessages = await _context.Messages.Where(k => k.ReceiverId == userId && k.SenderId == senderId).ToListAsync();

            return sentMessages;
        }
    }
}
