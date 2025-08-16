namespace GenialSchedule.Domain.Entities;

public sealed class Store : BaseEntity
{
    public Store(Guid tenantId,
    string name,
    string logoUrl,
    string bannerUrl,
    string aboutDescription,
    string segment)
    {
        SetTenant(tenantId);
        Name = name;
        LogoUrl = logoUrl;
        BannerUrl = bannerUrl;
        AboutDescription = aboutDescription;
        Segment = segment;
    }

    private readonly List<Employee> _employees = new();
    private readonly List<Service> _services = new();
    public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();
    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

    public string Name { get; } = default!;
    public string LogoUrl { get; }
    public string BannerUrl { get; }
    public string AboutDescription { get; }
    public string Segment { get; }

    public void AddEmployee(Employee employee)
    {
        if (!_employees.Contains(employee))
        {
            _employees.Add(employee);
        }
    }

    public void AddService(Service service)
    {
        if (!_services.Contains(service))
        {
            _services.Add(service);
        }
    }
}