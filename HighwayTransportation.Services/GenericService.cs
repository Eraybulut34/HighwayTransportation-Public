using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain;

namespace HighwayTransportation.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericService(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Add(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }


        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity Entity)
        {
            _dbSet.Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> OrderBy = null, Expression<Func<TEntity, object>> OrderByDesc = null, bool exception = false, bool WithCache = true)
        {
            await _dbSet.FindAsync(filter);
        }

        
    }
}
