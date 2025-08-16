using GenialSchedule.Domain.Entities;
using GenialSchedule.Infra.Providers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GenialSchedule.Infra.DataContexts
{
    public class AppDbContext : DbContext
    {
        private readonly ITenantProvider _tenant;

        public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenantProvider)
            : base(options) => _tenant = tenantProvider;

        public DbSet<User> Users => Set<User>();
        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<EmployeeServiceStore> EmployeeServiceStores => Set<EmployeeServiceStore>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Filtro global por TenantId
            foreach (var et in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(et.ClrType))
                {
                    var method = typeof(AppDbContext)
                        .GetMethod(nameof(ApplyTenantFilter), BindingFlags.NonPublic | BindingFlags.Static)!
                        .MakeGenericMethod(et.ClrType);

                    method.Invoke(null, new object[] { modelBuilder, this });
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        private static void ApplyTenantFilter<TEntity>(ModelBuilder b, AppDbContext ctx)
        where TEntity : BaseEntity
        => b.Entity<TEntity>().HasQueryFilter(e => e.TenantId == ctx._tenant.TenantId);
    }
}