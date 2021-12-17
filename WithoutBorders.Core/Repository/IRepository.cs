using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WithoutBorders.Core.Repository
{
    public interface IRepository <TKey, TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey entityKey);
        void Delete(TEntity entity);
        
        Task SaveAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        Task<int> CountAsync();

    }
}