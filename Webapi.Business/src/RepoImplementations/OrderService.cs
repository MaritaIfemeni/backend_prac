using AutoMapper;
using Webapi.Business.src.Dtos;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Domain.src.Entities;
using Webapi.Business.src.Abstractions;


namespace Webapi.Business.src.RepoImplementations
{
    public class OrderService: BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>, IOrderService
    {

        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo, IMapper mapper) : base(orderRepo, mapper)
        {
            _orderRepo = orderRepo;
        }
    }
}