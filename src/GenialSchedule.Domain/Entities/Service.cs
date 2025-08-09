namespace GenialSchedule.Domain.Entities;

public class Service : BaseEntity
{
    public Service(Guid tenantId,
    string name,
    string description,
    decimal price,
    string imageServiceUrl,
    Store store)
    {
        SetTenant(tenantId);
        Name = name;
        Description = description;
        Price = price;
        ImageServiceUrl = imageServiceUrl;
        Store = store;
    }

    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
    public string ImageServiceUrl { get; }
    public Guid StoreId { get; }
    public Store Store { get; }

    private readonly List<Employee> _employees = new List<Employee>();
    public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

    public void AssignEmployee(Employee employee)
    {
        if (!_employees.Contains(employee))
        {
            _employees.Add(employee);
        }
    }
}