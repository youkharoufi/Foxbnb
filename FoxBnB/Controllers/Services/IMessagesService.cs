using FoxBnB.Models;

namespace FoxBnB.Controllers.Services
{
    public interface IMessagesService
    {
        Task<List<Message>> GetSentMessages(string userId, string receiverId);
        Task<List<Message>> GetReceivedMessages(string userId, string senderId);
        Task<int> GetUnreadMessagesCount(string userId);
        Task<List<ApplicationUser>> GetAllUsersSenders(string userId);
    }
}
