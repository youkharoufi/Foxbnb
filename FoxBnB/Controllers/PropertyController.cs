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
        public async Task<ActionResult<DateRangeRes>> MakeAReservation(DateRangeRes reservation)
        {
            return Ok(await _propertyService.ReserveDateRange(reservation));
        }

        [HttpGet("get-all-reservations/{propertyId}")]
        public async Task<ActionResult<List<DateRangeRes>>> GetAllReservations(string propertyId)
        {
            return Ok(await _propertyService.GetAllReservedDates(propertyId));  
        }
    }
}
