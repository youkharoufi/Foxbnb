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
    }
}
