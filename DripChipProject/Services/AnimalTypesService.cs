using DripChipProject.Data;
using DripChipProject.Models;
using DripChipProject.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DripChipProject.Services
{
    public class AnimalTypesService : IAnimalTypesService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        public AnimalTypesService(IDbContextFactory<APIDbContext> contextFactory) 
        {
            this.contextFactory = contextFactory;
        }

        public AnimalType? GetTypes(long id)
        {
            var dbContext = contextFactory.CreateDbContext();
            return dbContext.AnimalTypes.FirstOrDefault(t => t.Id == id);
        }
    }
}
