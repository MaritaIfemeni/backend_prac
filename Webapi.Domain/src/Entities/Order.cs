namespace Webapi.Domain.src.Entities
{
    public class Order : BaseEntity
    {
        // Foreign key properties
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public string OrderDescription { get; set; } = string.Empty;

        // Navigation properties
        public User User { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
