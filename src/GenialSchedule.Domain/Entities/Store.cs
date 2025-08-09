namespace GenialSchedule.Domain.Entities;

public class Store : BaseEntity
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

    public string Name { get; }
    public string LogoUrl { get; }
    public string BannerUrl { get; }
    public string AboutDescription { get; }
    public string Segment { get; }

    private readonly List<Employee> _employees = new List<Employee>();
    public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

    private readonly List<Service> _services = new List<Service>();
    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

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