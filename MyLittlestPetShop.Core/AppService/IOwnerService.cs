using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetShop.Core.AppService
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        Owner FindOwnerById(int id);
        IEnumerable<Owner> GetAllOwners();
        Owner UpdateOwner(Owner ownerToUpdate);
        Owner DeleteOwner(int id);
        IEnumerable<Owner> GetFilteredOwners(Filter filter);
    }
}
