using Webapi.Domain.src.Shared;

namespace Webapi.Business.src.Abstractions
{
    public interface IBaseService<T, TDto>
    {
        
        IEnumerable<TDto> GetAll(QueryOptions queryOptions); 
        T GetOneById(string id);
        TDto UpdateOneById(string id, TDto updated);
        bool DeleteOneById();
    }
}