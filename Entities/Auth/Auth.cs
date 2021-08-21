using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Auth
{
    public class Auth : BaseEntity<Guid>
    {
        public Auth()
        {
            Id = Guid.NewGuid();
        }
        public string PhoneNumber { get; set; }

    }
    public class AuthConfiguartion : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(11);
            builder.HasIndex(p => p.PhoneNumber).IsUnique(true);
        }

    }
}
