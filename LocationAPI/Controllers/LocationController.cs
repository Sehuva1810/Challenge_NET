using LocationAPI.Abstractions.UseCases;
using LocationAPI.Models;
using LocationAPI.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(
        IGetAvailableLocationsUseCase getAvailableLocationsUseCase,
        IAddLocationUseCase addLocationUseCase
        )
        : ControllerBase
    {
        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAvailableLocations()
        {
            var locations =  await getAvailableLocationsUseCase.Execute(new());
            if (locations.Count == 0)
            {
                return NotFound("No locations are available between 10 am and 1 pm.");
            }
            return Ok(locations); 
        }
        
        // POST: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> AddLocation(Location location)
        {
            var result =  await addLocationUseCase.Execute(location);
            if (!result)
            {
                return NotFound("No locations are available between 10 am and 1 pm.");
            }
            return CreatedAtAction(nameof(GetAvailableLocations), new { id = location.Id }, location);
        }
    }
}