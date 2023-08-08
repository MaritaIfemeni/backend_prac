using Webapi.Business.src.Abstractions;
using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using AutoMapper;

namespace Webapi.Business.src.RepoImplementations
{
    public class ProductServices : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {

        private readonly IProductRepo _productRepo;
        public ProductServices(IProductRepo productRepo, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepo = productRepo;
        }
    }
}