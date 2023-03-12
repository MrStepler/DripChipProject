using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DripChipProject.Models
{
    public class Animal
    {
        public enum lifeStatus
        {
            ALIVE,
            DEATH
        }
        public enum gender
        {
            MAN,
            FEMALE,
            OTHER
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [NotMapped]
        [ForeignKey("AnimalType")]
        public virtual IQueryable<AnimalType> AnimalTypes { get; set; }
        public float Weight { get; set; }
        public float Lenght { get; set; }
        public float Height { get; set; }
        public gender Gender { get; set; } 
        public lifeStatus LifeStatus { get; set; } = lifeStatus.ALIVE;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime ChippingDateTime { get; set; }
        [ForeignKey("Account")]
        public int ChipperId { get; set; }
        public long ChippingLocationId { get; set; }
        [NotMapped]
        [ForeignKey("AnimalVisitedLocation")]
        public virtual IQueryable<AnimalVisitedLocation> VisitedLocations { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime? DeathDateTime { get; set; } = null;
    }
}
