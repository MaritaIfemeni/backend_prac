namespace Webapi.Domain.src.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
    }
}