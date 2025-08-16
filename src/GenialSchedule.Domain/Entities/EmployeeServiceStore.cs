namespace GenialSchedule.Domain.Entities
{
    public sealed class EmployeeServiceStore : BaseEntity
    {
        public Guid StoreId { get; private set; }

        public Guid ServiceId { get; private set; }
        public Guid EmployeeId { get; private set; }

        public Store Store { get; private set; } = default!;

        public Service Service { get; private set; } = default!;
        public Employee Employee { get; private set; } = default!;

        private EmployeeServiceStore()
        { } // EF

        public EmployeeServiceStore(Guid tenantId, Guid storeId, Guid serviceId, Guid employeeId)
        {
            SetTenant(tenantId);
            StoreId = storeId;
            ServiceId = serviceId;
            EmployeeId = employeeId;
        }

        public void ReassignService(Guid newServiceId)
        {
            if (newServiceId == Guid.Empty) throw new ArgumentException("ServiceId inválido", nameof(newServiceId));
            ServiceId = newServiceId;
            Touch(); // se seu BaseEntity tiver UpdatedAt
        }
    }
}