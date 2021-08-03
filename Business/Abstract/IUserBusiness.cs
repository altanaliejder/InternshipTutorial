using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserBusiness
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
         void TestUow();
    }
}
