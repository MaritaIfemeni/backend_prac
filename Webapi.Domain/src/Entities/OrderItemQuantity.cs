namespace Webapi.Domain.src.Entities
{
    public class OrderItemQuantity
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; } 
        public int Quantity { get; set; }

        // Navigation properties
        public OrderDetail OrderDetail { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
