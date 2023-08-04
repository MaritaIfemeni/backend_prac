namespace Webapi.Domain.src.Entities
{
    public class Order : BaseEntity
    {
        public User UserId { get; set; } = null!;
        public Payment PaymentId { get; set; } = null!;
        public string OrderDescription { get; set; } = string.Empty;
    }
}
