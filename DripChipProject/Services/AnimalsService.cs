using DripChipProject.Data;
using DripChipProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DripChipProject.Services
{
    public class AnimalsService : IAnimalsService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        public AnimalsService(IDbContextFactory<APIDbContext> contextFactory) 
        {
            this.contextFactory = contextFactory;
        }
        public Animal? GetAnimalById(long id)
        {
            var dbContext = contextFactory.CreateDbContext();
            return dbContext.Animals.FirstOrDefault(a => a.Id == id);
        }

        public Animal[]? SearchAnimal(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? chippingLocationId, Animal.lifeStatus? lifeStatus, Animal.gender? gender, int from = 0, int size = 10)
        {
            var dbContext = contextFactory.CreateDbContext();
            var searchedAnimals = dbContext.Animals.AsQueryable();
            if (startDateTime != null)
            {
                 searchedAnimals = searchedAnimals.Where(x => x.ChippingDateTime > startDateTime);
            }
            if (endDateTime != null)
            {
                searchedAnimals = searchedAnimals.Where(x => x.ChippingDateTime < endDateTime);
            }
            if (chipperId != null)
            {
                searchedAnimals = searchedAnimals.Where(x => x.ChipperId == chipperId);
            }
            if (chippingLocationId != null)
            {
                searchedAnimals = searchedAnimals.Where(x => x.ChippingLocationId == chippingLocationId);
            }
            if (lifeStatus != null)
            {
                searchedAnimals = searchedAnimals.Where(x => x.LifeStatus == lifeStatus);
            }
            if (gender != null)
            {
                searchedAnimals = searchedAnimals.Where(x => x.Gender == gender);
            }
            if (searchedAnimals.Count() == 0)
            {
                return null;
            }
            
            return searchedAnimals.OrderBy(x => x.Id).Skip(from).Take(size).ToArray();
        }
    }
}
