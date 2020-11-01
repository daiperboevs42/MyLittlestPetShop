using System;
using System.Collections.Generic;
using System.Text;
using MyLittlestPetShop.Core.Entity;

namespace MyLittlestPetShop.Core.AppService
{
    public interface IPetService
    {
        Pet CreatePet(Pet pet);
        IEnumerable<Pet> GetAllPets();
        Pet GetPetWithId(int id);
        Pet RemovePet(int id);
        Pet UpdatePetAPI(Pet petToUpdate);
        IEnumerable<Pet> GetFilteredPets(Filter filter);
    }
}
