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
        [HttpGet("{animalId}")]
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
        [HttpGet("search")]
        public IActionResult SearchAnimal([FromQuery] DateTime? startDateTime, [FromQuery] DateTime? endDateTime, [FromQuery] int? chipperId, [FromQuery] long? chippingLocationId, [FromQuery] lifeStatus? lifeStatus, [FromQuery] gender? gender, [FromQuery] int from, [FromQuery] int size) 
        {
            if (animalService.SearchAnimal(startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender, from, size) == null)
            {
                return StatusCode(404);
            }
            return Ok(animalService.SearchAnimal(startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender, from, size));
        }
        [HttpGet("types/{typeId}")]
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
    }
}
