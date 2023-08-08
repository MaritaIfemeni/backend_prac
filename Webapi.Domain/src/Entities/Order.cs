namespace Webapi.Domain.src.Entities
{
    public class Order : BaseEntity
    {

        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }

    public enum OrderStatus
    {
        Processing,
        Shipped
    }
}
