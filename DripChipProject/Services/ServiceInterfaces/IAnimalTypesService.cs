using DripChipProject.Models;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface IAnimalTypesService
    {
        AnimalType? GetTypes(long id);
    }
}
