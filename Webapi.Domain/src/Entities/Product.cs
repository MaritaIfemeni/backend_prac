using System;
namespace Webapi.Domain.src.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Image> ProductImages { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

