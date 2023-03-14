using DripChipProject.Models;
using static DripChipProject.Models.Animal;
using System.Drawing;
using DripChipProject.Models.ResponseModels.Animal;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface IAnimalsService
    {
        Animal? GetAnimalById(long id);
        Animal ChipAnimal(CreateAnimal createdAnimal);
        bool ExistAnimalWithType(long typeId);
        Animal[]? SearchAnimal(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? chippingLocationId, string? lifeStatus, string? gender, int from, int size);
        AnimalVisitedLocation[]? GetVisitedLocation(long animalId, DateTime? startDateTime, DateTime? endDateTime, int from, int size);
    }

}
