using Webapi.Domain.src.Entities;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


    }
}