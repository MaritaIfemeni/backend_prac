using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Dtos
{
    public class OrderDetailReadDto
    {
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
    }

        public class OrderDetailCreateDto
    {
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
    }
        public class OrderDetailUpdateDto
    {
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
    }
}