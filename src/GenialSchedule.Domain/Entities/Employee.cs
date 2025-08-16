using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Entities
{
    public sealed class Employee : Person
    {
        public Employee(Guid tenantId, string name, string email, ServiceType service)
        {
            SetTenant(tenantId);
            Name = new Name(name);
            Email = new Email(email);

            ServiceTypes = new List<ServiceType>
            {
                service
            };
        }

        public Guid StoreId { get; private set; }
        public Store Store { get; private set; } = default!;

        public static void UpdateName(string name) => new Name(name);

        public ICollection<ServiceType> ServiceTypes { get; }

        public void AddNewService(ServiceType service) => ServiceTypes.Add(service);

        public void RemoveService(ServiceType service) => ServiceTypes.Remove(service);
    }
}