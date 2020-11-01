using System;
using System.Collections.Generic;
using System.Text;
using MyLittlestPetShop.Core.Entity;

namespace MyLittlestPetShop.Core.DataService
{
    public interface IPetRepo
    {
        Pet Create(Pet pet);
        IEnumerable<Pet> ReadAllPets(Filter filter = null);
        Pet ReadyById(int id);
        Pet PetRanAway(int id);
        int Count();
        Pet UpdatePetInDB(Pet pet);
    }
}
