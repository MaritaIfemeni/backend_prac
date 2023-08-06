using System;
namespace Webapi.Domain.src.Entities
{
    public class Product: BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public List<Image> ProductImg { get; set; }
        public Category CategoryId { get; set; } = null!;

    }
}
