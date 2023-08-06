using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Business.src.Dtos
{
    public class PaymentDto
    {
        public float Amount { get; set; }
        public bool PaymentSuccess { get; set; }
        public string Provider { get; set; } = string.Empty;
    }
}