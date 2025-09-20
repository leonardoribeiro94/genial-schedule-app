using GenialSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenialSchedule.Infra.EntityConfigurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(1000)
                .IsRequired();

            builder.ComplexProperty(t => t.Email, email =>
            {
                email.Property(p => p.Address)
                .HasColumnName("Email")
                .HasMaxLength(256);
            });

            builder.Property(x => x.StoreId)
                .IsRequired();

            builder.HasMany(t => t.ServiceTypes)
        }
    }
}
