using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetShop.Core.AppService
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType petType);
        IEnumerable<PetType> GetAllPetTypes();
        PetType GetPetTypeWithId(int id);
        PetType RemovePetType(int id);
        PetType UpdatePetType(PetType petTypeToUpdate);
        IEnumerable<PetType> GetFilteredPetTypes(Filter filter);
    }
}
