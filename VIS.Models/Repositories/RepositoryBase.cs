using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VIS.Models.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext DbContext { get; set; }

        public RepositoryBase(DbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public virtual void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps)
        {
            return GetManyQueryable(predicate).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps)
        {
            return await Task.FromResult(Get(predicate));
        }

        public virtual List<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps)
        {
            return GetManyQueryable(predicate).ToList();
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps)
        {
            return await Task.FromResult(GetMany(predicate));
        }

        public virtual IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> predicate = null, params string[] includeProps)
        {
            var query = DbContext.Set<TEntity>().AsQueryable();

            if (includeProps != null)
            {
                foreach (var item in includeProps)
                {
                    query.Include(item);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public void Update(TEntity entity)
        {
            var entry = DbContext.Entry(entity);

            entry.State = EntityState.Modified;
        }

        public EntityState GetEntityState(TEntity entity)
        {
            return DbContext.Entry(entity).State;
        }
    }
}