using DripChipProject.Models;
using DripChipProject.Models.ResponseModels.AnimalType;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface IAnimalTypesService
    {
        AnimalType? GetType(long id);
        AnimalType? GetType(string type);
        List<AnimalType>? GetListTypesOfAnimal(long animalId);
        AnimalType AddType(string type);
        AnimalType EditType(long id, string type);
        void DeleteType(long typeId);
        long[] GetTypesByAnimalId(long animalId);
        Animal AddTypeToAnimal(long animalId, long typeId);
        Animal EditTypeOfAnimal(long animalId, SwitchableTypes switchableTypes);
        Animal DeleteTypeOfAnimal(long animalId, long typeId);
    }
}
