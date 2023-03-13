using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DripChipProject.Models
{
    public class AnimalVisitedLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
        [Required]
        public long LocationPointId { get; set; }

        [AllowNull]
        public long? animalID { get; set; }
        [ForeignKey("animalID")]
        [AllowNull]
        public Animal? Animal { get; set; }
    }
}
