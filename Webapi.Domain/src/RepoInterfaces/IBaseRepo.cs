using Webapi.Domain.src.Shared;

namespace Webapi.Domain.src.RepoInterfaces
{
    public interface IBaseRepo<T> /// should not work with the DTO:s, uses orginal entities
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryOptions);  // should consider the sorting, searching and pagination all from here
        Task<T?> GetOneById(Guid id);
        Task<T> UpdateOneById(T updatedEntity);
        Task<bool> DeleteOneById(T entityToDelete);
        Task<T> CreateOne(T entityToCreate);
    }


}