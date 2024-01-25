using FoxBnB.Controllers.Services;
using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessagesService _messagesService;
        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }


        [HttpGet("get-sent-messages/{userId}/{receiverId}")]
        public async Task<ActionResult<List<Message>>> GetAllSentMessages(string userId, string receiverId)
        {
            return Ok(await _messagesService.GetSentMessages(userId, receiverId));
        }

        [HttpGet("get-received-messages/{senderId}/{userId}")]
        public async Task<ActionResult<List<Message>>> GetAllReceivedMessages(string senderId, string userId)
        {
            return Ok(await _messagesService.GetReceivedMessages(senderId, userId));
        }

    }
}
