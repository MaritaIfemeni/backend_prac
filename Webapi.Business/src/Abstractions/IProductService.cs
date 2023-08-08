using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Abstractions
{
    public interface IProductService : IBaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        
    }
}