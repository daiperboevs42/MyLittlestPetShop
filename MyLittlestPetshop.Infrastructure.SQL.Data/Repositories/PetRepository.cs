using Microsoft.EntityFrameworkCore;
using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittlestPetshop.Infrastructure.SQL.Data.Repositories
{
    public class PetRepository : IPetRepo
    {
        private PetshopAppContext _ctx;

        public PetRepository(PetshopAppContext ctx)
        {
            _ctx = ctx;
        }
        public Pet Create(Pet pet)
        {
            var pt = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pt;
        }

        public Pet PetRanAway(int id)
        {
            Pet pet = ReadyById(id);
            _ctx.Attach(pet).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadAllPets(Filter filter)
        {
            if(filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.Pets.Include(o => o.Owner).Include(p => p.PetType);
            }
            return _ctx.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
        public Pet ReadyById(int id)
        {
            return _ctx.Pets.Include(o => o.Owner).Include(p => p.PetType).FirstOrDefault(c => c.Id == id);
        }

        public Pet UpdatePetInDB(Pet pet)
        {
            _ctx.Attach(pet).State = EntityState.Modified;
            _ctx.SaveChanges();
            return pet;
        }
    }
}