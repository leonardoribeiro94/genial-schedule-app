namespace GenialSchedule.Domain.Entities;

public class Service(string name,
    string description,
    decimal price,
    string imageServiceUrl,
    Store store) : BaseEntity
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public decimal Price { get; } = price;
    public string ImageServiceUrl { get; } = imageServiceUrl;
    public int StoreId { get; }
    public Store Store { get; } = store;

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