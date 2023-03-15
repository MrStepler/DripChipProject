using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DripChipProject.Models
{
    public class Animal
    {
        public enum lifeStatus
        {
            ALIVE,
            DEAD
        }
        public enum gender
        {
            MALE,
            FEMALE,
            OTHER
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public ICollection<AnimalType> AnimalTypes { get; set; }
        public float Weight { get; set; }
        public float Lenght { get; set; }
        public float Height { get; set; }
        public gender Gender { get; set; } 
        public lifeStatus LifeStatus { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime ChippingDateTime { get; set; }
        [ForeignKey("Account")]
        public int ChipperId { get; set; }
        public long ChippingLocationId { get; set; }
        public ICollection<AnimalVisitedLocation> VisitedLocations { get; set; }
        [AllowNull]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime? DeathDateTime { get; set; }
    }
}
