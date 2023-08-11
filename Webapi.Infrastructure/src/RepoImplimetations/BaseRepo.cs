using Microsoft.EntityFrameworkCore;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Domain.src.Shared;
using Webapi.Infrastructure.src.Database;

namespace Webapi.Infrastructure.src.RepoImplimetations
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        private readonly DatabaseContex _context;
        public BaseRepo(DatabaseContex dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _context = dbContext;
        }
        public virtual async Task<T> CreateOne(T entityToCreate)
        {
            await _dbSet.AddAsync(entityToCreate);
            await _context.SaveChangesAsync();
            return entityToCreate;
        }

        public async Task<bool> DeleteOneById(T entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetOneById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateOneById(T orginalEntity, T updatedEntity)
        {
            _dbSet.Update(updatedEntity);
            await _context.SaveChangesAsync();
            return updatedEntity;
        }
    }
}