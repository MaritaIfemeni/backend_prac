using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Domain.src.Entities
{
    public class Image: BaseEntity
    {
        public string Link { get; set; } = string.Empty;
    }
}