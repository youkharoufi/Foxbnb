using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace FoxBnB.Chat
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> UserConnections = new ConcurrentDictionary<string, string>();
        private readonly DatabaseContext _context;
        public ChatHub(DatabaseContext context)
        {
            _context = context;
        }
        public override Task OnConnectedAsync()
        {
            UserConnections[Context.ConnectionId] = Context.User.Identity.Name; // Or any unique identifier
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserConnections.TryRemove(Context.ConnectionId, out _);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(Message chatMessage)
        {
            var receiverConnectionId = UserConnections.FirstOrDefault(c => c.Value == chatMessage.ReceiverId).Key;
            if (!string.IsNullOrEmpty(receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", chatMessage);
            }

            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();

            // Optionally, echo the message back to the sender
            await Clients.Caller.SendAsync("ReceiveMessage", chatMessage);
        }
    }

}
