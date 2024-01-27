using FoxBnB.Controllers.Services;
using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoxBnB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }


        [HttpGet("all-properties")]
        public async Task<ActionResult<List<Property>>> GetAllProperties()
        {
            return Ok(await _propertyService.GetAllProperties());
        }

        [HttpGet("property-by-id/{propertyId}")]
        public async Task<ActionResult<Property>> GetPropertyById(string propertyId)
        {
            if (propertyId == null) return BadRequest("propertyId is null");

            return Ok(await _propertyService.GetPropertyById(propertyId));
        }

        [HttpGet("properties-by-type/{type}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByType(string type)
        {
            return Ok(await _propertyService.GetPropertiesByType(type));
        }

        [HttpPost("make-reservation")]
        public async Task<ActionResult<List<DayInfo>>> MakeAReservation(DayInfoDto dayInfoDto)
        {
            return Ok(await _propertyService.ReserveDateRange(dayInfoDto));
        }

        [HttpGet("get-all-reservations/{propertyId}")]
        public async Task<ActionResult<List<DayInfo>>> GetAllReservations(string propertyId)
        {
            return Ok(await _propertyService.GetAllReservedDates(propertyId));  
        }

        [HttpPost("is-booked/{propertyId}")]
        public async Task<ActionResult<bool>> IsBooked(string propertyId,[FromForm] string dayString)
        {
            DateTime day;
            if (!DateTime.TryParse(dayString, out day))
            {
                return BadRequest("Date not parsed correctyly");
            }
            return Ok(await _propertyService.IsBooked(propertyId, day.Date));
        }
    }
}
