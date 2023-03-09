using DripChipProject.Data;
using DripChipProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DripChipProject.Services
{
    public class LocationService : ILocationService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        public LocationService(IDbContextFactory<APIDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public AnimalLocation? GetLocation(long pointId)
        {
            var dbContext = contextFactory.CreateDbContext();
            return dbContext.Locations.FirstOrDefault(x => x.Id == pointId);
        }
    }
}
