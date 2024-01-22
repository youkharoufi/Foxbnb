namespace FoxBnB.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public bool Read { get; set; }
    }
}
