using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepo;

        public PetService(IPetRepository perReposit)
        {
            _petRepo = perReposit;
        }

        public Pet CreatePet(Pet pe)
        {
            return _petRepo.Create(pe);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.FindPetbyId(id);
        }

        public List<Pet> getASC()
        {
            return GetPets().OrderBy(o => o.Price).ToList();
        }

        public List<Pet> getCheapest()
        {
            var cheapPets = getASC();
            return cheapPets.Take(5).ToList();
        }

        public List<Pet> getDESC()
        {
            return GetPets().OrderByDescending(o => o.Price).ToList();
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public void InitDatabaseData()
        {
            _petRepo.IntialiseData();
        }

        public Pet NewPet(string name, string previousOwner, double price, DateTime soldDate, DateTime birthDate, string color)
        {
            var pe = new Pet()
            {
                Name = name,
                PreviousOwner = previousOwner,
                Price = price,
                SoldDate = soldDate,
                BirthDate = birthDate,
                Color = color
            };

            return pe;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.ID);
            pet.Name = petUpdate.Name;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;
            pet.SoldDate = petUpdate.SoldDate;
            pet.BirthDate = petUpdate.BirthDate;
            pet.Color = petUpdate.Color;
            return pet;
        }

    }
}
