using DripChipProject.Models;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface IAnimalTypesService
    {
        AnimalType? GetTypes(long id);
        AnimalType? GetTypes(string type);
        AnimalType AddType(string type);
        AnimalType EditType(long id, string type);
    }
}
