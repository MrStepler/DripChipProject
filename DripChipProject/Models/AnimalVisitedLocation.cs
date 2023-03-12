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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
        [Required]
        public long LocationPointId { get; set; }
        public virtual Animal Animal { get; set; } = null!;
    }
}
