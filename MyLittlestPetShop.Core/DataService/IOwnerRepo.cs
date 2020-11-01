using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetShop.Core.DataService
{
    public interface IOwnerRepo
    {
        Owner Create(Owner owner);
        Owner ReadyById(int id);
        IEnumerable<Owner> ReadAllOwner(Filter filter = null);
        Owner Update(Owner OwnerToUpdate);
        Owner Delete(int id);
        int Count();
        Owner FindOwnerByIdIncludingPets(int id);
    }
}
