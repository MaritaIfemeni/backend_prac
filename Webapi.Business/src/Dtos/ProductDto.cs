using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Dtos
{
    public class ProductDto
    {
        
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public List<Image> ProductImg { get; set; }
        public CategoryDto Category { get; set; } = null!;

    }
}