using Microsoft.EntityFrameworkCore;
using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittlestPetshop.Infrastructure.SQL.Data.Repositories
{
    public class OwnerRepository : IOwnerRepo
    {
        private PetshopAppContext _ctx;

        public OwnerRepository(PetshopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {
            var own =_ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return own;
        }
        public int Count()
        {
            return _ctx.Owners.Count();
        }

        public Owner Delete(int id)
        {
            var removedOwner = ReadyById(id);
            _ctx.Attach(removedOwner).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return removedOwner;
        }

        public Owner FindOwnerByIdIncludingPets(int id)
        {
            return _ctx.Owners.Include(c => c.Pets).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Owner> ReadAllOwner(Filter filter)
        {
            if (filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.Owners.Include(c => c.Pets);
            }
            return _ctx.Owners
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Owner ReadyById(int id)
        {
            return _ctx.Owners.FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner OwnerToUpdate)
        {
            _ctx.Attach(OwnerToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return OwnerToUpdate;
        }
    }
}
