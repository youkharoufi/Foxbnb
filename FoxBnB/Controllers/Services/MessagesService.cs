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

            var messagesOfUser = await _context.Messages.Where(n=>n.ReceiverId == userId && n.Read == false).ToListAsync();

            return messagesOfUser.Count;
        }

        public async Task<List<Message>> ReadMessages(string senderId, string receiverId)
        {
            var messages = await _context.Messages.Where(i => i.SenderId == senderId && i.ReceiverId == receiverId).ToListAsync();

            foreach(var message in messages)
            {
                message.Read = true;
                await _context.SaveChangesAsync();
               
            }

            return messages;

    
        }

        public async Task<List<ApplicationUser>> GetAllMessageSenders(string currentUserId)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            var allMessagesReceived = await _context.Messages.Where(msg => msg.ReceiverId == currentUserId).ToListAsync();

            var allSenderUsers = new List<ApplicationUser>();

            foreach(var message in allMessagesReceived)
            {
                var senderUser = await _userManager.FindByIdAsync(message.SenderId);
                if(senderUser != null)
                {
                    allSenderUsers.Add(senderUser);
                }

            }

            return allSenderUsers;
        }

        public async Task<int> GetMessageCountPerUserSender(string senderId, string receiverId)
        {
            var unreadMessages = await _context.Messages.Where(n=>n.SenderId == senderId && n.ReceiverId == receiverId && n.Read == false).ToListAsync();

            return unreadMessages.Count;
        }

    }
}
