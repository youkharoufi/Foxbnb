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
        private readonly DatabaseContext _context;

        public MessagesController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet("get-messages")]
        public async Task<ActionResult<List<Message>>> GetAllMessages(string senderId, string receiverId)
        {
            var messages = await _context.Messages.Where(m => m.SenderId == senderId && m.ReceiverId == receiverId).ToListAsync();

            return Ok(messages);
        }

    }
}
