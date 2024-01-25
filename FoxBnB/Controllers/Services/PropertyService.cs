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

        public async Task<DateRangeRes> ReserveDateRange(DateRangeRes reservation)
        {
            var days = new List<DateTime>();

            for (DateTime day = reservation.StartDate; day <= reservation.EndDate; day = day.AddDays(1))
            {
                days.Add(day);
            }

            reservation.DaysInRange = days;
            await _context.DateRanges.AddAsync(reservation);

            await _context.SaveChangesAsync();

            return reservation;


        }

        public async Task<List<DateRangeRes>> GetAllReservedDates(string propertyId)
        {
            var property = await _context.DateRanges.Where(x => x.PropertyId == propertyId).ToListAsync();

            return property;
        }
    }
}
