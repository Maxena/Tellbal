using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class PriceAverage : BaseEntity<Guid>
    {
        public long Price { get; set; }
        public DateTime UpdatedPriceTime { get; set; }
    }
    public class PriceAverageConfiguartion : IEntityTypeConfiguration<PriceAverage>
    {
        public void Configure(EntityTypeBuilder<PriceAverage> builder)
        {
            builder.HasKey(p => p.Id);
        }

    }

}
