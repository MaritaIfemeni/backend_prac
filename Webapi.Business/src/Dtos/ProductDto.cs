using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Dtos
{
    public class ProductDto
    {
        
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Image> ProductImages { get; set; } = new List<Image>();
    }
}