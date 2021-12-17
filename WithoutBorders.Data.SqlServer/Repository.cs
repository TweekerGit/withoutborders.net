using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WithoutBorders.Core;
using WithoutBorders.Core.Repository;

namespace WithoutBorders.Data.SqlServer
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>, new()
    {
        protected DbSet<TEntity> db;
        private AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.db = context.Set<TEntity>();
        }


        public void Create(TEntity entity) => db.Add(entity);

        public void Update(TEntity entity) => db.Update(entity);
        public void Delete(TKey entityKey) => db.Remove(new TEntity {Id = entityKey});

        public void Delete(TEntity entity) => db.Remove(entity);

        public async Task SaveAsync() => await this.context.SaveChangesAsync();

        public async Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes) =>
            await includes.Aggregate(this.db.AsQueryable(),
                (current, include) => current.Include(include)).FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes) =>
            await includes.Aggregate(this.db.Where(filter), (current, include) => current.Include(include))
                .ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes) =>
            await includes.Aggregate(this.db.AsQueryable(), (current, include) => current.Include(include))
                .ToListAsync();

        public async Task<int> CountAsync() => await this.db.CountAsync();
    }
}
