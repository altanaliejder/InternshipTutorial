using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserBusiness : IUserBusiness
    {
        IRepository<User> _repository;
        EfUnitOfWork efUnitOfWork;
        TestContext _context;

        public UserBusiness(IRepository<User> repository, TestContext context)
        {
            _repository = repository;
            _context = context;
            efUnitOfWork = new EfUnitOfWork(_context);
        }
        public void Add(User user)
        {
            efUnitOfWork.GetRepository<User>().Add(user);
            efUnitOfWork.SaveChanges();
            
        }

        public void Delete(User user)
        {
            efUnitOfWork.GetRepository<User>().Delete(user);
            efUnitOfWork.SaveChanges();
        }

        public List<User> GetAll()
        {
            return efUnitOfWork.GetRepository<User>().GetAll();
        }

        public User GetById(int id)
        {
            return efUnitOfWork.GetRepository<User>().Get(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return efUnitOfWork.GetRepository<User>().Get(x => x.Username == username);
        }

        public void Update(User user)
        {
            efUnitOfWork.GetRepository<User>().Update(user);
            efUnitOfWork.SaveChanges();
        }

        public void TestUow()
        {
            User user1 = new User();
            User user2 = new User();
            user1.Name = "asssacd";
            user2.Name = "ccvdad";
            user2.Id = 1;

            efUnitOfWork.GetRepository<User>().Add(user1);
            efUnitOfWork.GetRepository<User>().Add(user2);
            efUnitOfWork.SaveChanges();
        }
    }
}
