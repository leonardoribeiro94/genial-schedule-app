using GenialSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenialSchedule.Infra.EntityConfigurations
{
    public class StoreConfigurations : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(t => t.LogoUrl);

            builder.Property(t => t.BannerUrl);

            builder.Property(t => t.AboutDescription)
                .HasMaxLength(1000);

            builder.HasMany(t => t.Employees)
                .WithOne(t => t.Store)
                .HasForeignKey(t => t.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Services)
                .WithOne(t => t.Store)
                .HasForeignKey(t => t.StoreId);

            builder.HasIndex(t => new { t.TenantId, t.Id, t.Name });
        }
    }
}