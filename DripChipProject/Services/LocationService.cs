using DripChipProject.Data;
using DripChipProject.Models;
using DripChipProject.Models.ResponseModels.Locations;
using DripChipProject.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DripChipProject.Services
{
    public class LocationService : ILocationService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        public LocationService(IDbContextFactory<APIDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public AnimalLocation AddLocation(EditCreateLocation location)
        {
            using var dbContext = contextFactory.CreateDbContext();
            AnimalLocation createdLocation = new AnimalLocation();
            createdLocation.Latitude = location.Latitude;
            createdLocation.Longitude = location.Longitude;
            dbContext.Add(createdLocation);
            dbContext.SaveChanges();
            return createdLocation;
        }

        public void DeleteLocation(long pointId)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var deletableLocation = dbContext.Locations.Find(pointId);
            dbContext.Remove(deletableLocation);
            dbContext.SaveChanges();
        }

        public AnimalLocation EditLocation(long pointid, EditCreateLocation location)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var editableLocation = dbContext.Locations.Find(pointid);
            editableLocation.Latitude = location.Latitude;
            editableLocation.Longitude = location.Longitude;

            dbContext.SaveChanges();
            return editableLocation;
        }

        public AnimalLocation? GetLocation(long pointId)
        {
            using var dbContext = contextFactory.CreateDbContext();
            return dbContext.Locations.FirstOrDefault(x => x.Id == pointId);
        }

        public AnimalLocation? GetLocation(EditCreateLocation location)
        {
            using var dbContext = contextFactory.CreateDbContext();
            if (dbContext.Locations.Where(x => x.Latitude == location.Latitude && x.Longitude == location.Longitude) == null)
            {
                return null;
            }
            return dbContext.Locations.FirstOrDefault(x => x.Latitude == location.Latitude && x.Longitude == location.Longitude);
        }
    }
}
