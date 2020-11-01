
using MyLittlestPetShop.Core.DataService;
using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetshop.Infrastructure.SQL.Data.Repositories
{
    public class UserRepository : IUserRepo
    {
        private PetshopAppContext _ctx;

        public UserRepository(PetshopAppContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<User> ReadAllUsers()
        {
            return _ctx.Users;
        }
    }
}
