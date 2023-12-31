using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Abstractions
{
    public interface IOrderService : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        
    }
}