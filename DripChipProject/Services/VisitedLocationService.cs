using DripChipProject.Data;
using DripChipProject.Models;
using DripChipProject.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DripChipProject.Services
{
    public class VisitedLocationService : IVisitedLocationService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        public VisitedLocationService(IDbContextFactory<APIDbContext> contextFactory) 
        {
            this.contextFactory = contextFactory;
        }

        public long[] GetVisitedLocations(long animalId)
        {
            using var dbContext = contextFactory.CreateDbContext();
            return dbContext.VisitedLocations.Where(x => x.animalID == animalId).Select(x => x.Id).ToArray();
        }

        public AnimalVisitedLocation VisitVisitedLocation(long pointId)
        {
            using var dbContext = contextFactory.CreateDbContext();
            AnimalVisitedLocation visitedLocation = new AnimalVisitedLocation();
            visitedLocation.LocationPointId = pointId;
            visitedLocation.DateTimeOfVisitLocationPoint = DateTime.Now;
            dbContext.VisitedLocations.Add(visitedLocation);
            dbContext.SaveChanges();
            return visitedLocation;
        }
    }
}
