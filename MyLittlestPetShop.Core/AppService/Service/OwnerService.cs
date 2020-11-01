using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyLittlestPetShop.Core.AppService.Service
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepo _ownerRepo;
        private IPetRepo _petRepo;

        public OwnerService(IOwnerRepo ownerRepo,
            IPetRepo petRepo)
        {
            _ownerRepo = ownerRepo;
            _petRepo = petRepo;
        }

        public Owner New()
        {
            return new Owner();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.Delete(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadyById(id);
        }

        public IEnumerable<Owner> GetFilteredOwners(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _ownerRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }
            return _ownerRepo.ReadAllOwner(filter).ToList();
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            return _ownerRepo.Update(ownerToUpdate);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAllOwner();
        }

    }
}
