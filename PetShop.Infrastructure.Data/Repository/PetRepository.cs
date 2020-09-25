using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data.Repository
{
    public class PetRepository: IPetRepository
    {
        static int id = 1;
        private static List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pe)
        {
            pe.ID = id++;
            _pets.Add(pe);
            return pe;
        }

        public Pet Delete(int id)
        {
            var petFound = this.FindPetbyId(id);
            if(petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }
            return null;
        }

        public Pet FindPetbyId(int id)
        {
            foreach (var pet in _pets)
            {
                if(pet.ID == id)
                {
                    return pet;
                }
            }

            return null;
        }

        public void IntialiseData()
        {
            _pets = FakeDB.InitDataPet();
            IDAfterInit();
        }

        private void IDAfterInit()
        {
            id = FakeDB.getID();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _pets;
        }
    }
}
