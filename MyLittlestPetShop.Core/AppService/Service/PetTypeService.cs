using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittlestPetShop.Core.AppService.Service
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepo _petTypeRepo;

        public PetTypeService(IPetTypeRepo petTypeRepo)
        {
            _petTypeRepo = petTypeRepo;
        }
        public PetType CreatePetType(PetType petType)
        {
            return _petTypeRepo.Create(petType);
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _petTypeRepo.ReadAllPetTypes().ToList();
        }

        public IEnumerable<PetType> GetFilteredPetTypes(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _petTypeRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }
            return _petTypeRepo.ReadAllPetTypes(filter).ToList();
        }

        public PetType GetPetTypeWithId(int id)
        {
            return _petTypeRepo.ReadyById(id);
        }

        public PetType RemovePetType(int id)
        {
            return _petTypeRepo.DeletePetType(id);
        }

        public PetType UpdatePetType(PetType petTypeToUpdate)
        {
            var petType = GetPetTypeWithId(petTypeToUpdate.Id);
            petType.TypeName = petTypeToUpdate.TypeName;
            return petType;
        }
    }
}
