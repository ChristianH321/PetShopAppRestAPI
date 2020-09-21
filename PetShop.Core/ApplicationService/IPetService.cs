using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet CreatePet(Pet pe);
        Pet DeletePet(int id);
        Pet FindPetById(int id);
        List<Pet> getASC();
        List<Pet> getCheapest();
        List<Pet> getDESC();
        List<Pet> GetPets();
        void InitDatabaseData();
        Pet NewPet(string name, string previousOwner, double price, DateTime soldDate, DateTime birthDate, string color);
        Pet UpdatePet(Pet petUpdate);
    }
}
