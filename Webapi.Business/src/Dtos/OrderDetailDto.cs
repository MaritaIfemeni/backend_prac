using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Dtos
{
    public class OrderDetailReadDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDetailCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderDetailUpdateDto
    {

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}