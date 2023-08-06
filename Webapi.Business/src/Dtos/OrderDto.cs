using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Dtos
{
    public class OrderDto
    {
        public UserDto User { get; set; } = null!;
        public PaymentDto Payment { get; set; } = null!;
        public string OrderDescription { get; set; } = string.Empty;
        public List<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();
        public List<OrderItemQuantity> OrderItemQuantities { get; set; } = new List<OrderItemQuantity>();
    }
}