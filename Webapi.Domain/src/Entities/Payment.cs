using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Domain.src.Entities
{
    public class Payment : BaseEntity
    {
        public float Amount { get; set; }
        public bool PaymentSuccess { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
