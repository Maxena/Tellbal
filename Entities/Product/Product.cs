using Entities.Product.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class Product: BaseEntity<Guid>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string About { get; set; }
        public int Discount { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<Image> Images { get; set; }
        [JsonIgnore]
        public ICollection<PriceAverage> PriceAverages { get; set; }
        [JsonIgnore]
        public ICollection<DynamicProperty> DynamicProperties { get; set; }
        [JsonIgnore]
        public ICollection<PropertyValue> PropertyValues { get; set; }
        [JsonIgnore]
        public Warranty Warranty { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
    public enum ProductType
    {
        [Display(Name = "New")]
        New = 0,
        [Display(Name = "Used")]
        Used = 1
    }
    public class ProductConfiguartion : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).HasMaxLength(100);
        }

    }
}
