namespace FoxBnB.Models
{

    public class DayInfo
    {
        public string Id { get; set; }
        public string PropertyId { get; set; }
        public DateTime Date { get; set; }
        public bool Booked { get; set; } = false;
    }
}
