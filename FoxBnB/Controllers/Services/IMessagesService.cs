using FoxBnB.Models;

namespace FoxBnB.Controllers.Services
{
    public interface IMessagesService
    {
        Task<List<Message>> GetSentMessages(string userId, string receiverId);
        Task<List<Message>> GetReceivedMessages(string userId, string senderId);
        Task<int> GetUnreadMessagesCount(string userId);
        Task<List<ApplicationUser>> GetAllMessageSenders(string currentUserId);
        Task<int> GetMessageCountPerUserSender(string senderId, string receiverId);
        Task<List<Message>> ReadMessages(string senderId, string receiverId);


    }
}
