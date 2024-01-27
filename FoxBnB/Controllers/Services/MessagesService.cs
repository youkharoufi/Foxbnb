using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.Controllers.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MessagesService(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<int> GetUnreadMessagesCount(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var messagesOfUser = await _context.Messages.Where(n=>n.ReceiverId == userId).ToListAsync();

            return messagesOfUser.Count;
        }

        public async Task<List<ApplicationUser>> GetAllUsersSenders(string userId)
        {
            var users = new List<ApplicationUser>();

            var messagesReceived = await _context.Messages.Where(j => j.ReceiverId == userId && j.Read == false).ToListAsync();

            foreach (var message in messagesReceived)
            {
                var sender = await _userManager.FindByIdAsync(message.SenderId);
                if (sender != null)
                {
                    users.Add(sender);
                }
            }

            return users;
        }

    }
}
