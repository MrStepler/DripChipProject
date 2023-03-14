using System.ComponentModel.DataAnnotations;
using DripChipProject.Models;
namespace DripChipProject.Models.ResponseModels.AnimalType
{
    public class AnimalTypeDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public AnimalTypeDTO(Models.AnimalType animalType) 
        {
            Id = animalType.Id;
            Type = animalType.Type;
        }
    }
}
