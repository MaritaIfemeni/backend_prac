using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
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

        public virtual async Task<bool> DeleteOneById(T entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        // public virtual async Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        // {
        //     return await _dbSet.ToArrayAsync(); //TODO: need to implement the queryOptions
        // }
        public async Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            var entities = _dbSet.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(queryOptions.Search))
            {
                entities = entities.Where(entity =>
                    entity.ToString().Contains(queryOptions.Search, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(queryOptions.Search))
            {
                var parameter = Expression.Parameter(typeof(T), "entity");
                var property = Expression.Property(parameter, queryOptions.Search);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var searchValue = Expression.Constant(queryOptions.Search, typeof(string));
                var containsExpression = Expression.Call(property, containsMethod, searchValue);
                var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
                entities = entities.Where(lambda);
            }

            if (!string.IsNullOrWhiteSpace(queryOptions.Order))
            {
                var propertyInfo = typeof(T).GetProperty(queryOptions.Order,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    entities = queryOptions.OrderDescending
                        ? entities.OrderByDescending(entity => EF.Property<object>(entity, queryOptions.Order))
                        : entities.OrderBy(entity => EF.Property<object>(entity, queryOptions.Order));
                }
            }

            entities = entities.Skip((queryOptions.PageNumber - 1) * queryOptions.PageSize)
                .Take(queryOptions.PageSize);

            return await entities.ToListAsync();
        }


        public virtual async Task<T?> GetOneById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> UpdateOneById(T updatedEntity)
        {
            _dbSet.Update(updatedEntity);
            await _context.SaveChangesAsync();
            return updatedEntity;
        }
    }
}