using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Dtos
{
    public class OrderReadDto
    {
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetailReadDto> OrderDetailReadDto { get; set; }
    }

    public class OrderCreateDto
    {
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetailCreateDto> OrderDetailCreateDto { get; set; }
    }

    public class OrderUpdateDto
    {
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetailUpdateDto> OrderDetailUpdateDto { get; set; }
    }
}