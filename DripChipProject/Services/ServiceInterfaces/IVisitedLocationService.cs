using DripChipProject.Models;

namespace DripChipProject.Services.ServiceInterfaces
{
    public interface IVisitedLocationService
    {
        AnimalVisitedLocation VisitLocation(long animalId, long pointId);
        long[]? GetVisitedLocationsIDs(long animalId);
        AnimalVisitedLocation? GetVisitedLocationsById(long visitedPointId);
        AnimalVisitedLocation EditVisitedLocation(long visitedPointId, long newPointId);
        List<AnimalVisitedLocation>? GetListVisistedLocationsOfAnimal(long animalId);
        void DeleteVisitedLocation(long animalId, long visitedPointId);
    }
}
