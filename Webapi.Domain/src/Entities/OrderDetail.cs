using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Domain.src.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Order OrderId { get; set; } = null!;
        public Product ProductId { get; set; } = null!;
        public bool Shipped { get; set; } = false;
    }
}