using Microsoft.EntityFrameworkCore;
using Shopping.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Shopping.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ShoppingContext shoppingContext;
        private readonly DbSet<TEntity> dataSet;

        public GenericRepository(ShoppingContext shoppingContext)
        {
            this.shoppingContext = shoppingContext;
            dataSet = shoppingContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            dataSet.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity deleteEntity = dataSet.Find(id);
            Delete(deleteEntity);
        }

        public void Delete(TEntity entityToDelete)
        {
            if(shoppingContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dataSet.Attach(entityToDelete);
            }
            dataSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dataSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }
            foreach(var includeProperty in includeProperties.Split
                (new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetByID(object oid)
        {
            return dataSet.Find(oid);
        }

        public void Update(TEntity entityToUpdate)
        {
            dataSet.Update(entityToUpdate);
        }
    }
}
