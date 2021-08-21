using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Entities.Auth
{
    public class Otp : BaseEntity<Guid>
    {
        public int Code { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receptor { get; set; }
        public int Cost { get; set; }
        public DateTime Date { get; set; }
        public string StatusText { get; set; }
        public Auth Auth { get; set; }

    }
    public class OtpConfiguration : IEntityTypeConfiguration<Otp>
    {
        public void Configure(EntityTypeBuilder<Otp> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(4);
            builder.Property(p => p.Message).HasMaxLength(100);
            builder.Property(p => p.Receptor).IsRequired();
            builder.Property(p => p.Receptor).HasMaxLength(11);
            builder.Property(p => p.Sender).HasMaxLength(20);
            builder.Property(p => p.StatusText).HasMaxLength(100);
        }
    }
}
