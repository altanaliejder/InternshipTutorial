using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private TestContext _testContext;


        public EfUnitOfWork(TestContext testContext)
        {

            _testContext = testContext;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EfRepositoryBase<T>(_testContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _testContext.SaveChanges();
            }
            catch (Exception)
            {
                this.Dispose();
                return -1;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _testContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
