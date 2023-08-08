using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Domain.src.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}