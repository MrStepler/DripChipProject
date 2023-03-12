using DripChipProject.Models;
using static DripChipProject.Models.Animal;
using System.Drawing;

namespace DripChipProject.Services
{
    public interface IAnimalsService
    {
        Animal? GetAnimalById(long id);
        Animal[]? SearchAnimal(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? chippingLocationId, lifeStatus? lifeStatus, gender? gender, int from, int size);
        AnimalVisitedLocation[]? GetVisitedLocation(long animalId, DateTime? startDateTime, DateTime? endDateTime, int from, int size);
    }

}
