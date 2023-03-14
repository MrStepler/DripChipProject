using System.ComponentModel.DataAnnotations;

namespace DripChipProject.Models.ResponseModels.Locations
{
    public class VisitedLocationDTO
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
        
        public long LocationPointId { get; set; }
        public VisitedLocationDTO(AnimalVisitedLocation animalVisitedLocation) 
        {
            Id = animalVisitedLocation.Id;
            DateTimeOfVisitLocationPoint = animalVisitedLocation.DateTimeOfVisitLocationPoint;
            LocationPointId = animalVisitedLocation.LocationPointId;
        }
    }
}
