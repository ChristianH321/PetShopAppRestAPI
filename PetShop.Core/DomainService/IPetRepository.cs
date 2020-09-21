using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
        Pet Create(Pet pe);
        Pet FindPetbyId(int id);
        void IntialiseData();
        Pet Delete(int id);
    }
}
