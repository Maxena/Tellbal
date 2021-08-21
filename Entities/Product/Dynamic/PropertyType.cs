using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product.Dynamic
{
    public class PropertyType : BaseEntity
    {
        public string TypeName { get; set; }
        public ICollection<DynamicProperty> DynamicProperties { get; set; }
    }
}
