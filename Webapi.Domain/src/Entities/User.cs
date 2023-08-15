using System.Text.Json.Serialization;

namespace Webapi.Domain.src.Entities
{
    public class User : BaseEntity
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[] Salt { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }

        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        Admin = 1,
        User = 2
    }
}
