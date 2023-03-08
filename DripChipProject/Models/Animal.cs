using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DripChipProject.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public virtual ICollection<AnimalType> animalTypes { get; set; }
        public float weight { get; set; }
        public float lenght { get; set; }
        public float height { get; set; }
        public Gender gender { get; set; } 
        public enum Gender
        {
            MAN, 
            FEMALE, 
            OTHER
        }
        public LifeStatus lifeStatus { get; set; }
        public enum LifeStatus 
        { 
            ALIVE,
            DEATH
        } 
        public DateTime chippingDateTime { get; set; }
        [ForeignKey("Account")]
        public int chipperId { get; set; }
        public long chippingLocationId { get; set; }
        public virtual ICollection<AnimalVisitedLocation> visitedLocations { get; set; } = null!;
        public DateTime? deathDateTime { get; set; } = null;
    }
}
