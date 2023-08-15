using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapi.Domain.src.Shared;

namespace Webapi.Controller.src.Controllers
{
    //[Authorize]
    public class ProductController : CrudController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {

        private readonly IProductService _productService;
        public ProductController(IProductService baseService) : base(baseService)
        {
            _productService = baseService;
        }

        [AllowAnonymous]
        public override async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return Ok(await _productService.GetAll(queryOptions));
        }

        
        [AllowAnonymous]
        public override async Task<ActionResult<ProductReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await _productService.GetOneById(id));
        }


    }
}