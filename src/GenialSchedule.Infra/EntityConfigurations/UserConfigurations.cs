using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenialSchedule.Infra.EntityConfigurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(t => t.Id);

            builder.ComplexProperty(t => t.Email, email =>
            {
                email.Property(p => p.Address)
                .HasColumnName("Email")
                .HasMaxLength(256);
            });

            builder.ComplexProperty(t => t.Document, doc =>
            {
                doc.Property(d => d.Number)
                .HasColumnName("Document")
                .HasMaxLength(20);
            });

            builder.ComplexProperty(t => t.PhoneNumber, phone =>
            {
                phone.Property(p => p.Phone)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(20);
            });

            builder.Property(t => t.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Birthday)
                .HasColumnType("date");

            builder.HasIndex(t => new { t.TenantId, t.Email.Address }).IsUnique();
        }
    }
}