using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetShop.Core.DataService
{
    public interface IUserRepo
    {
        IEnumerable<User> ReadAllUsers();
    }
}
