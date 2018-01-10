using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Login.Interfaces
{
    internal interface IRepository<TEntity, TId> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(TId id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TId> entities);
        TEntity Find(TId id);
        TEntity Find(TId id, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Find(IEnumerable<TId> ids);
        DbSet<TEntity> Set { get; set; }
        List<TEntity> All();
        List<TEntity> All(params Expression<Func<TEntity, object>>[] includes);
        List<TEntity> All(IEnumerable<TId> collection);
        List<TEntity> All(IEnumerable<TId> collection, params Expression<Func<TEntity, object>>[] includes);
        void Update(TEntity entity);
    }
}
