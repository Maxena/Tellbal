using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Entities.User
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        [JsonIgnore]
        public DateTime LastLoginDate { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public DateTime DeletedAt { get; set; }
        public ICollection<Province> Province { get; set; }
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(11);
            builder.HasIndex(p => p.PhoneNumber).IsUnique(true);
            builder.Property(p => p.FullName).IsRequired();
            //builder.Ignore(p => p.LastLoginDate);
            //builder.Ignore(p => p.CreatedAt);
            //builder.Ignore(p => p.UpdatedAt);
            //builder.Ignore(p => p.DeletedAt);
        }
    }
}
