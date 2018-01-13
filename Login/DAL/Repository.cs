using WebDBApp.Database;
using WebDBApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WebDBApp.DAL
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected AppDbContext Context;

        public DbSet<TEntity> Set
        {
            get;
            set;
        }

        public Repository(AppDbContext dbContext)
        {
            Context = dbContext;
            Set = dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public void Remove(TId id)
        {
            Set.Remove(Find(id));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TId> entities)
        {
            Set.RemoveRange(entities.Select(Find));
        }

        public virtual TEntity Find(TId id)
        {
            return Set.Find(id);
        }

        public virtual TEntity Find(TId id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = new List<TEntity>() { Set.Find(id) }.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.First();
        }

        public IEnumerable<TEntity> Find(IEnumerable<TId> ids)
        {
            return ids.Select(Find).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual List<TEntity> All()
        {
            return Set.ToList();
        }

        public List<TEntity> All(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Set.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.ToList();
        }

        public virtual List<TEntity> All(IEnumerable<TId> collection, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = collection.Select(Find).AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.ToList();
        }

        public virtual List<TEntity> All(IEnumerable<TId> collection)
        {
            return collection.Select(Find).ToList();
        }
    }
}