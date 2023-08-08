using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Abstractions
{
    public interface IOrderDetailService : IBaseService<OrderDetail, OrderDetailReadDto, OrderDetailCreateDto, OrderDetailUpdateDto>
    {
        
    }
}