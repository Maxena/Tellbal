using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product.Dynamic
{
    public class DynamicProperty : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public ICollection<PropertyValue> PropertyValues { get; set; }
    }
}
