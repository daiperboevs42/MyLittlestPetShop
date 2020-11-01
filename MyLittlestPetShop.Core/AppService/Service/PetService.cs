using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;

namespace MyLittlestPetShop.Core.AppService.Service
{
    public class PetService : IPetService
    {
        private IPetRepo _petRepo;

        public PetService(IPetRepo petRepo)
        {
            _petRepo = petRepo;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _petRepo.ReadAllPets();
        }

        public IEnumerable<Pet> GetFilteredPets(Filter filter)
        {
            if(filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or above");
            }
            if((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _petRepo.Count())
            {
                throw new InvalidDataException("Index is out of bounds");
            }

            return _petRepo.ReadAllPets(filter).ToList();
        }

        public Pet GetPetWithId(int id)
        {
            return _petRepo.ReadyById(id);
        }

        public Pet RemovePet(int id)
        {
            return _petRepo.PetRanAway(id);
        }

        public Pet UpdatePetAPI(Pet petToUpdate)
        {
            var pet = GetPetWithId(petToUpdate.Id);
            pet.Name = petToUpdate.Name;
            pet.Price = petToUpdate.Price;
            pet.Color = petToUpdate.Color;
            pet.Description = petToUpdate.Description;
            return pet;
        }
    }
}
