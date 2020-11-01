using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetShop.Core.DataService
{
    public interface IPetTypeRepo
    {
        PetType Create(PetType petType);
        IEnumerable<PetType> ReadAllPetTypes(Filter filter = null);
        PetType ReadyById(int id);
        PetType DeletePetType(int id);
        int Count();
        PetType UpdatePetType(PetType petType);
    }
}
