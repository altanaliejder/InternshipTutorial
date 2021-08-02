using Business.Abstract;
using DataAccess.Abstract;
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

        public UserBusiness(IRepository<User> repository)
        {
            _repository = repository;
        }
        public void Add(User user)
        {
            _repository.Add(user);
        }

        public void Delete(User user)
        {
            _repository.Delete(user);
        }

        public List<User> GetAll()
        {
            return _repository.getAll();
        }

        public User GetById(int id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _repository.Get(x => x.Username == username);
        }

        public void Update(User user)
        {
            _repository.Update(user);
        }
    }
}
