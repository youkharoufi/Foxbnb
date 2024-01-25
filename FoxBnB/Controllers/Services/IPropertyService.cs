using FoxBnB.Models;

namespace FoxBnB.Controllers.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllProperties();
        Task<Property> GetPropertyById(string propertyId);
        Task<List<Property>> GetPropertiesByType(string type);
        Task<List<DateRangeRes>> GetAllReservedDates(string propertyId);
        Task<DateRangeRes> ReserveDateRange(DateRangeRes reservation);
    }
}
