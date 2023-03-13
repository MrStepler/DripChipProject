using DripChipProject.Models;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface IVisitedLocationService
    {
        AnimalVisitedLocation VisitVisitedLocation(long pointId);
        long[] GetVisitedLocations(long animalId);
    }
}
