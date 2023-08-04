using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Domain.src.Shared;

namespace Webapi.Domain.src.RepoInterfaces
{
    public interface IBaseRepo<T> /// should not work with the DTO:s, uses orginal entities
    {
        IEnumerable<T> GetAll(QueryOptions queryOptions);  // should consider the sorting, searching and pagination all from here
        T GetOneById(string id);
        T UpdateOneById(T updatedEntity);
        bool DeleteOneById();
    }


}