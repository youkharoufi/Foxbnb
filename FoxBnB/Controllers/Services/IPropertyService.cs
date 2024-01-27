using FoxBnB.Models;

namespace FoxBnB.Controllers.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllProperties();
        Task<Property> GetPropertyById(string propertyId);
        Task<List<Property>> GetPropertiesByType(string type);
        Task<List<DayInfo>> GetAllReservedDates(string propertyId);
        Task<List<DayInfo>> ReserveDateRange(DayInfoDto dateInfoDto);
        Task<bool> IsBooked(string propertyId, DateTime day);
    }
}
