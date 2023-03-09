using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DripChipProject.Models
{
    public class AnimalVisitedLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
        [Required]
        public long LocationPointId { get; set; }
        public virtual Animal Animal { get; set; } = null!;
    }
}
