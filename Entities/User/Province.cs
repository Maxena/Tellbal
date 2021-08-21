using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.User
{
    public class Province : BaseEntity
    {
        public string State { get; set; }
        public string City { get; set; }
    }

    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(p => p.State).HasMaxLength(50);
            builder.Property(p => p.City).HasMaxLength(50);
        }
    }
}
