namespace FoxBnB.Models
{
    public class Property
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Type { get; set; }
        public string InfoParagraph { get; set; }
        public int TotalSpace { get; set; }
        public int FloorNumber { get; set; }
        public int NumberOfRooms { get; set; }
        public bool ParkingAvailable { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
    }
}
