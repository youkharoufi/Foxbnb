﻿namespace FoxBnB.Models
{
    public class DayInfoDto
    {
        public string PropertyId { get; set; }
        public string UserId { get; set; }
        public List<DateTime> AllDaysToBook { get; set; }
    }
}
