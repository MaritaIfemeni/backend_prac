using Webapi.Business.src.Abstractions;
using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using AutoMapper;

namespace Webapi.Business.src.RepoImplementations
{
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailReadDto, OrderDetailCreateDto, OrderDetailUpdateDto>, IOrderDetailService
    {
       
       private readonly IOrderDetailRepo _orderDetailRepo;

       public OrderDetailService(IOrderDetailRepo orderDetailRepo, IMapper mapper) : base(orderDetailRepo, mapper)
       {
           _orderDetailRepo = orderDetailRepo;
       }
    }
}