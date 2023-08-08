using Webapi.Domain.src.Shared;

namespace Webapi.Business.src.Abstractions
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        
        Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions); 
        Task<TReadDto> GetOneById(string id);
        Task<TReadDto> UpdateOneById(string id, TUpdateDto updated);
        Task<bool> DeleteOneById(string id);
        Task<TReadDto> CreateOne(TCreateDto entityToCreate);
        
    }
}