using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Entities
{
    public class Employee : Person
    {
        public Employee(string name, Email email, ServiceType service)
        {
            Name = new Name(name);
            Email = email;

            ServiceTypes = new List<ServiceType>
            {
                service
            };
        }

        public static void UpdateName(string name) => new Name(name);

        public ICollection<ServiceType> ServiceTypes { get; }

        public void AddNewService(ServiceType service) => ServiceTypes.Add(service);

        public void RemoveService(ServiceType service) => ServiceTypes.Remove(service);
    }
}