namespace GenialSchedule.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid TenantId { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        public void SetTenant(Guid tenantId) => TenantId = tenantId;

        public void Touch() => UpdatedAt = DateTime.UtcNow;
    }
}