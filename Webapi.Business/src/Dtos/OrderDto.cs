using Webapi.Domain.src.Entities;
using static Webapi.Domain.src.Entities.Order;

namespace Webapi.Business.src.Dtos
{
    public class OrderDto
    {
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetailDto> OrderDetailDto { get; set; }
    }
}