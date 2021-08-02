using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRepositoryBase<TEntity> : IRepository<TEntity>,IDisposable
        where TEntity:class,new()
    {
        private bool disposedValue;

        TestContext _context;
        public EfRepositoryBase(TestContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var AddedEntity = _context.Entry(entity);
            AddedEntity.State = EntityState.Added;
            _context.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
                return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> getAll(Expression<Func<TEntity, bool>> filter = null)
        {


                return filter == null
                    ? _context.Set<TEntity>().ToList()
                    : _context.Set<TEntity>().Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }



        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
