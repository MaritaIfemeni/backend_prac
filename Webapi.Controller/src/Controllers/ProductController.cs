using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;

namespace Webapi.Controller.src.Controllers
{
    public class ProductController : CrudController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        public ProductController(IProductService baseService) : base(baseService)
        {
        }
    }
}