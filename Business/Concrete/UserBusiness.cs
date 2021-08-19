using Autofac;
using Business.Abstract;
using Business.Attribute;
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
    public class UserBusiness : BaseBusiness,IUserBusiness
    {
        //IRepository<User> _repository;
        //EfUnitOfWork efUnitOfWork;
        //TestContext _context;

        public UserBusiness(ILifetimeScope currentContainer):base(currentContainer)
        {
            //_repository = repository;
            //_context = context;
            //efUnitOfWork = new EfUnitOfWork(_context);
        }
        public void Add(User user)
        {
            this.currentContainer.Resolve<IRepository<User>>().Add(user);
            this.currentContainer.Resolve<IUnitOfWork>().SaveChanges();
        }

        public void Delete(User user)
        {
            this.currentContainer.Resolve<IRepository<User>>().Delete(user);
            this.currentContainer.Resolve<IUnitOfWork>().SaveChanges();
        }

        [AuthorizeOperation("admin,moderator")]
        public List<User> GetAll()
        {
            return this.currentContainer.Resolve<IRepository<User>>().GetAll();
        }

        public User GetById(int id)
        {
            return this.currentContainer.Resolve<IRepository<User>>().Get(x => x.Id == id);
        }

        public User GetByMail(string mail)
        {
            return this.currentContainer.Resolve<IRepository<User>>().Get(x => x.Email == mail);
        }

        public void Update(User user)
        {
            this.currentContainer.Resolve<IRepository<User>>().Update(user);
            this.currentContainer.Resolve<IUnitOfWork>().SaveChanges();
        }

        public void TestUow()
        {
            User user1 = new User();
            User user2 = new User();
            user1.Name = "asssacd";
            user2.Name = "ccvdad";
            user2.Id = 1;

            this.currentContainer.Resolve<IRepository<User>>().Add(user1);
            this.currentContainer.Resolve<IRepository<User>>().Add(user2);
            this.currentContainer.Resolve<IUnitOfWork>().SaveChanges();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var context = this.currentContainer.Resolve<TestContext>();
            var result = from operationClaim in context.OperationClaim
                         join userOperationClaim in context.UserOperationClaim
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
