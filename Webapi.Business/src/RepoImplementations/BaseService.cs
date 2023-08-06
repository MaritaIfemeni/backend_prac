using Webapi.Business.src.Abstractions;
using Webapi.Domain.src.Shared;
using Webapi.Domain.src.RepoInterfaces;s

namespace Webapi.Business.src.RepoImplementations
{
    public class BaseService<T, TDto> : IBaseService<T, TDto>
    {
        private readonly IBaseRepo<T> _baseRepo;
        
        public bool DeleteOneById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDto> GetAll(QueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }

        public T GetOneById(string id)
        {
            throw new NotImplementedException();
        }

        public TDto UpdateOneById(string id, TDto updated)
        {
            throw new NotImplementedException();
        }
    }
}