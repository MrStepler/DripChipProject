using DripChipProject.Models;
using DripChipProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DripChipProject.Controllers
{
    [ApiController]
    public class LocationController : Controller
    {
        ILocationService locationService;
        public LocationController(ILocationService locationService) 
        {
            this.locationService = locationService;
        }
        [Route("locations/{pointId}")]
        [HttpGet]
        public ActionResult<AnimalLocation> GetLocation(long? pointId)
        {
            if (pointId == null || pointId <= 0)
            {
                return StatusCode(400);
            }
            if (locationService.GetLocation((long)pointId) == null)
            {
                return StatusCode(404);
            }
            return Ok(locationService.GetLocation((long)pointId));
        }
    }
}
