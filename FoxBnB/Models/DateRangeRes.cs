namespace FoxBnB.Models
{
    public class DateRangeRes
    {

        public string Id { get; set; }
        public string PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<DateTime>? DaysInRange = new List<DateTime>();
       

    }
}
