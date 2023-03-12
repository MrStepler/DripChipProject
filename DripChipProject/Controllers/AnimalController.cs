using DripChipProject.Models;
using DripChipProject.Services;
using Microsoft.AspNetCore.Mvc;
using static DripChipProject.Models.Animal;

namespace DripChipProject.Controllers
{
    [ApiController]
    public class AnimalController : Controller
    {
        IAnimalsService animalService;
        IAnimalTypesService animalTypesService;
        public AnimalController(IAnimalsService animalService, IAnimalTypesService animalTypesService)
        {
            this.animalService = animalService;
            this.animalTypesService = animalTypesService;   
        }
        [Route("animals/{animalId}")]
        [HttpGet]
        public IActionResult GetAnimal(long? animalId)
        {
            if (animalId == null || animalId <= 0) 
            {
                return StatusCode(400);
            }
            if (animalService.GetAnimalById((long)animalId) == null)
            {
                return StatusCode(404);
            }
            return Ok(animalService.GetAnimalById((long)animalId));
           
        }
        [Route("animals/search")]
        [HttpGet]
        public IActionResult SearchAnimal([FromQuery] DateTime? startDateTime, [FromQuery] DateTime? endDateTime, [FromQuery] int? chipperId, [FromQuery] long? chippingLocationId, [FromQuery] lifeStatus? lifeStatus, [FromQuery] gender? gender, [FromQuery] int from = 0, [FromQuery] int size = 10) 
        {
            if (animalService.SearchAnimal(startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender, from, size) == null)
            {
                // return StatusCode(404);
            }
            if (from < 0)
            {
                return StatusCode(400);
            }
            if (size <= 0)
            {
                return StatusCode(400);
            }
            return Ok(animalService.SearchAnimal(startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender, from, size));
        }
        [Route("animals/types/{typeId}")]
        [HttpGet]
        public ActionResult<AnimalType> GetAnimalType(long? typeId)
        {
            if (typeId == null || typeId <= 0)
            {
                return StatusCode(400);
            }
            if (animalTypesService.GetTypes((long)typeId) == null)
            {
                return StatusCode(404);
            }
            return Ok(animalTypesService.GetTypes((long)typeId));

        }
        [Route("animals/{animalId}/locations")]
        [HttpGet]
        public ActionResult<AnimalVisitedLocation> GetVistedLocations(long? animalId, [FromQuery] DateTime? startDateTime, [FromQuery] DateTime? endDateTime, [FromQuery] int from = 0, [FromQuery] int size = 10)
        {
            if (animalId == null || animalId <= 0)
            {
                return StatusCode(400);
            }
            if (from <0)
            {
                return StatusCode(400);
            }
            if (size <= 0)
            {
                return StatusCode(400);
            }
            return Ok(animalService.GetVisitedLocation((long)animalId, startDateTime, endDateTime, from, size));
        }
    }
}
