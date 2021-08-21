using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product.Dynamic
{
    public class PropertyValue : BaseEntity<Guid>
    {
        public string Value { get; set; }
        public PropertyItem PropertyItem { get; set; }
    }
}
