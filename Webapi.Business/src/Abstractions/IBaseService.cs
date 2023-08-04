using Webapi.Domain.src.Shared;

namespace Webapi.Business.src.Abstractions
{
    public interface IBaseService<T>
    {
        
        IEnumerable<T> GetAll(QueryOptions queryOptions);  // should consider the sorting, searching and pagination all from here
        T GetOneById(string id);
        T UpdateOneById(T updatedEntity);
        bool DeleteOneById();
    }
}