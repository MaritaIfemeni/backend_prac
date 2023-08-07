using Webapi.Domain.src.Shared;

namespace Webapi.Business.src.Abstractions
{
    public interface IBaseService<T, TDto>
    {
        
        IEnumerable<TDto> GetAll(QueryOptions queryOptions); 
        TDto GetOneById(string id);
        TDto UpdateOneById(string id, TDto updated);
        bool DeleteOneById(string id);
        
    }
}