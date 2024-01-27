using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.Controllers.Services
{
    public class PropertyService : IPropertyService
    {

        private readonly DatabaseContext _context;

        public PropertyService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property> GetPropertyById(string propertyId)
        {
            return await _context.Properties.Where(p => p.Id == propertyId).FirstOrDefaultAsync();
        }

        public async Task<List<Property>> GetPropertiesByType(string type)
        {
            return await _context.Properties.Where(p => p.Type == type).ToListAsync();
        }

        public async Task<List<DayInfo>> ReserveDateRange(DayInfoDto dateInfoDto)
        {
            var days = new List<DayInfo>();

            foreach(var day in dateInfoDto.AllDaysToBook)
            {
                var newDayToAdd = new DayInfo();
                newDayToAdd.Id = Guid.NewGuid().ToString();
                newDayToAdd.Date = day.Date;
                newDayToAdd.Booked = true;
                newDayToAdd.PropertyId = dateInfoDto.PropertyId;

                days.Add(newDayToAdd);
            }

            foreach(var day in days)
            {
                var result = await _context.DaysInfo.AddAsync(day);
                await _context.SaveChangesAsync();

            }

            
            
            return days;



        }

        public async Task<List<DayInfo>> GetAllReservedDates(string propertyId)
        {
            var bookedDays = new List<DayInfo>();

            bookedDays = await _context.DaysInfo.Where(dinfo => dinfo.PropertyId == propertyId && dinfo.Booked == true).ToListAsync();

            return bookedDays;

            
        }

        public async Task<bool> IsBooked(string propertyId, DateTime day)
        {
            var sku = await _context.DaysInfo.Where(i=>i.PropertyId == propertyId && i.Date.Date == day.Date).FirstOrDefaultAsync();

            return sku?.Booked == true;


        }
    }
}
