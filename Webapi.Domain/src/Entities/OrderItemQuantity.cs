namespace Webapi.Domain.src.Entities
{
    public class OrderItemQuantity
    {
        public OrderDetail OrderDetailId { get; set; } = null!;
        public Product ProductId { get; set; } = null!;
        public int Quantity { get; set; }
    }
}