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

        public AnimalType AddType(string type)
        {
            using var dbContext = contextFactory.CreateDbContext();
            AnimalType createdType = new AnimalType();
            createdType.Type = type;
            dbContext.AnimalTypes.Add(createdType);
            dbContext.SaveChanges();
            return createdType;
        }

        public AnimalType EditType(long id, string type)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var editableType = dbContext.AnimalTypes.Find(id);
            editableType.Type = type;
            dbContext.SaveChanges();
            return editableType;
        }

        public AnimalType? GetTypes(long id)
        {
            using var dbContext = contextFactory.CreateDbContext();
            return dbContext.AnimalTypes.FirstOrDefault(t => t.Id == id);
        }
        public long[] GetTypesByAnimalId(long animalId)
        {
            using var dbContext = contextFactory.CreateDbContext();
            return dbContext.AnimalTypes.Where(t => t.AnimalId == animalId).Select(t => t.Id).ToArray();
        }
        public AnimalType? GetTypes(string type)
        {
            using var dbContext = contextFactory.CreateDbContext();
            return dbContext.AnimalTypes.FirstOrDefault(t => t.Type == type);
        }
    }
}
