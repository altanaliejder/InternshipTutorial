using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        TestContext _context;
        public EfRepositoryBase(TestContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var AddedEntity = _context.Entry(entity);
            AddedEntity.State = EntityState.Added;
           

        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            

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
            

        }

    }
}
