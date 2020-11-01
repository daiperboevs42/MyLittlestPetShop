using Microsoft.EntityFrameworkCore;
using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittlestPetshop.Infrastructure.SQL.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepo
    {
        private PetshopAppContext _ctx;

        public PetTypeRepository(PetshopAppContext ctx)
        {
            _ctx = ctx;
        }

        public PetType Create(PetType petType)
        {
            var pt = _ctx.PetTypes.Add(petType).Entity;
            _ctx.SaveChanges();
            return pt;
        }

        public PetType DeletePetType(int id)
        {
            PetType petType = ReadyById(id);
            _ctx.Attach(petType).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return petType;
        }
        public int Count()
        {
            return _ctx.PetTypes.Count();
        }

        public IEnumerable<PetType> ReadAllPetTypes(Filter filter)
        {
            if (filter.ItemsPrPage == 0 && filter.CurrentPage == 0)
            {
                return _ctx.PetTypes;
            }
            return _ctx.PetTypes
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public PetType ReadyById(int id)
        {
            return _ctx.PetTypes.FirstOrDefault(c => c.Id == id);
        }

        public PetType UpdatePetType(PetType petType)
        {
            _ctx.Attach(petType).State = EntityState.Modified;
            _ctx.SaveChanges();
            return petType;
        }
    }
}
