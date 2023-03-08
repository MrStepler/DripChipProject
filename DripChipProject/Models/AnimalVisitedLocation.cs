using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DripChipProject.Models
{
    public class AnimalVisitedLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public DateTime dateTimeOfVisitLocationPoint { get; set; }
        public long locationPointId { get; set; }
        public virtual Animal Animal { get; set; } = null!;
    }
}
