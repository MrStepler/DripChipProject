using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using DripChipProject.Models;

namespace DripChipProject.Models.ResponseModels.Animal
{
    public class AnimalDTO
    {
        public long Id { get; set; }
        public long[]? AnimalTypes { get; set; }
        public float Weight { get; set; }
        public float Lenght { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }
        public string LifeStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime ChippingDateTime { get; set; }
        public int ChipperId { get; set; }
        public long ChippingLocationId { get; set; }
        public long[]? VisitedLocations { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime? DeathDateTime { get; set; }
        public AnimalDTO(Models.Animal animal)
        {
            Id = animal.Id;
            Weight = animal.Weight;
            Lenght = animal.Lenght;
            Height = animal.Height;
            if (animal.Gender == Models.Animal.gender.FEMALE)
            {
                Gender = "FEMALE";
            }
            if (animal.Gender == Models.Animal.gender.MALE)
            {
                Gender = "MALE";
            }
            if (animal.Gender == Models.Animal.gender.OTHER)
            {
                Gender = "OTHER";
            }
            if(animal.LifeStatus == Models.Animal.lifeStatus.ALIVE)
            {
                LifeStatus = "ALIVE";
            }
            if (animal.LifeStatus == Models.Animal.lifeStatus.DEATH)
            {
                LifeStatus = "DEATH";
            }
            ChipperId= animal.ChipperId;
            ChippingDateTime= animal.ChippingDateTime;
            DeathDateTime= animal.DeathDateTime;

        }
    }
}
