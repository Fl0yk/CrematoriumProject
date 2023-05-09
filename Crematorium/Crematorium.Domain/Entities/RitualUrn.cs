using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Domain.Entities
{
    public class RitualUrn : Entity
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
    }
}
