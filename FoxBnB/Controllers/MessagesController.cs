﻿using FoxBnB.Controllers.Services;
using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

        [HttpGet("unread-message-count/{userId}")]
        public async Task<ActionResult<int>> GetUnreadMessagesCount(string userId)
        {
            return Ok(await _messagesService.GetUnreadMessagesCount(userId));
        }

        [HttpGet("all-senders-users/{userId}")]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllSendersUsers(string userId)
        {
            return Ok(await _messagesService.GetAllMessageSenders(userId));  
        }

        [HttpPost("read-messages/{senderId}/{receiverId}")]
        public async Task<ActionResult<List<Message>>> ReadMessages(String senderId, string receiverId)
        {
            return Ok(await _messagesService.ReadMessages(senderId, receiverId));
        }

        [HttpGet("unread-messages-count-per-user/{senderId}/{receiverId}")]
        public async Task<ActionResult<int>> GetUnreadMessagesCountPerUser(string senderId, string receiverId)
        {

            return Ok(await _messagesService.GetMessageCountPerUserSender(senderId, receiverId));
        }

    }
}
