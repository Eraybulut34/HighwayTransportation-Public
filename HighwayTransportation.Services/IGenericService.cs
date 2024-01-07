

//         public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
//         {
//             return await _dbSet.Where(predicate).ToListAsync();
//         }

//         public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
//         {
//             return await _dbSet.SingleOrDefaultAsync(predicate);
//         }

//         public async Task AddAsync(TEntity entity)
//         {
//             await _dbSet.AddAsync(entity);
//             await _context.SaveChangesAsync();
//         }

//         public async Task AddRangeAsync(IEnumerable<TEntity> entities)
//         {
//             await _dbSet.AddRangeAsync(entities);
//             await _context.SaveChangesAsync();
//         }

//         public async Task RemoveAsync(TEntity entity)
//         {
//             _dbSet.Remove(entity);
//             await _context.SaveChangesAsync();
//         }

//         public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
//         {
//             _dbSet.RemoveRange(entities);
//             await _context.SaveChangesAsync();
//         }

        
//     }
// }




using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HighwayTransportation.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> GetByQueryAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task Add(List<TEntity> entity);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(List<TEntity> entities);

        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        //Delete
        Task Delete(int Id);
        Task Delete(TEntity Entity);
        //Get
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        

    }
}
