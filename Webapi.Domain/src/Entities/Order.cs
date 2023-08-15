using System.Text.Json.Serialization;

namespace Webapi.Domain.src.Entities
{
    public class Order : BaseEntity
    {

        public OrderStatus OrderStatus { get; set; }
        public string FullName { get; set; }
        public string DeliveryAddress { get; set; }
        public Guid UserId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }

     [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Processing = 1,
        Shipped = 2
    }
}
