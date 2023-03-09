using DripChipProject.Models;
namespace DripChipProject.Services
{
    public interface IAnimalTypesService
    {
        AnimalType? GetTypes(long id);
    }
}
