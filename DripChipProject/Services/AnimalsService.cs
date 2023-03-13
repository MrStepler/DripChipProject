using DripChipProject.Data;
using DripChipProject.Models;
using DripChipProject.Models.ResponseModels.Animal;
using DripChipProject.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DripChipProject.Services
{
    public class AnimalsService : IAnimalsService
    {
        IDbContextFactory<APIDbContext> contextFactory;
        IVisitedLocationService visitedLocationService;
        public AnimalsService(IDbContextFactory<APIDbContext> contextFactory, IVisitedLocationService visitedLocationService) 
        {
            this.contextFactory = contextFactory;
            this.visitedLocationService = visitedLocationService;
        }
        public Animal? GetAnimalById(long id)
        {
            var dbContext = contextFactory.CreateDbContext();
            return dbContext.Animals.FirstOrDefault(a => a.Id == id);
        }

        public Animal[]? SearchAnimal(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? chippingLocationId, Animal.lifeStatus? lifeStatus, Animal.gender? gender, int from, int size)
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
        public AnimalVisitedLocation[]? GetVisitedLocation(long animalId, DateTime? startDateTime, DateTime? endDateTime, int from, int size)
        {
            var dbContext = contextFactory.CreateDbContext();
            var LocationIndexes = dbContext.VisitedLocations.Where(x => x.Animal.Id == animalId);
            if (startDateTime != null)
            {
                LocationIndexes = LocationIndexes.Where(x => x.DateTimeOfVisitLocationPoint > startDateTime);
            }
            if (endDateTime != null)
            {
                LocationIndexes = LocationIndexes.Where(x => x.DateTimeOfVisitLocationPoint < endDateTime);
            }
            return LocationIndexes.Skip(from).Take(size).ToArray();

        }

        public bool ExistAnimalWithType(long typeId)
        {
            using var dbContext = contextFactory.CreateDbContext();
            var animalsWithType = dbContext.AnimalTypes.Where(x => x.Id == typeId).Where(x =>x.Animal != null);

            if (animalsWithType.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public Animal ChipAnimal(CreateAnimal createdAnimal) // NOT READY YET
        {
            using var dbContext = contextFactory.CreateDbContext();
            Animal animal = new Animal();
            animal.Weight = (float)createdAnimal.Weight;
            animal.Height = (float)createdAnimal.Height;
            animal.Lenght = (float)createdAnimal.Lenght;
            if (createdAnimal.Gender == "FEMALE")
            {
                animal.Gender = Animal.gender.FEMALE;
            }
            if (createdAnimal.Gender == "MALE")
            {
                animal.Gender = Animal.gender.MALE;
            }
            if (createdAnimal.Gender == "OTHER")
            {
                animal.Gender = Animal.gender.OTHER;
            }
            animal.ChipperId = (int)createdAnimal.ChipperId;
            animal.ChippingLocationId = (long)createdAnimal.ChippingLocationId;
            animal.LifeStatus = Animal.lifeStatus.ALIVE;
            animal.ChippingDateTime = DateTime.Now;
            animal.DeathDateTime = null;
            AnimalVisitedLocation animalVisitedLocation = new AnimalVisitedLocation();
            animalVisitedLocation.DateTimeOfVisitLocationPoint = DateTime.Now;
            animalVisitedLocation.LocationPointId = animal.ChippingLocationId;
            animalVisitedLocation.Animal = animal;
            animal.VisitedLocations = new List<AnimalVisitedLocation>();
            foreach (long typeAnimalInd in createdAnimal.AnimalTypes)
            {
                var typeAnimal = dbContext.AnimalTypes.Find(typeAnimalInd);
                typeAnimal.Animal = animal;
            }
            animal.AnimalTypes = new List<AnimalType>();
            dbContext.VisitedLocations.Add(animalVisitedLocation);
            dbContext.Animals.Add(animal);
            dbContext.SaveChanges();
            return animal;
        }
    }
}
