using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VIS.Models.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbContext DbContext { get; set; }

        TEntity Get(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps);

        List<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps);

        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps);

        IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps);

        EntityState GetEntityState(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
