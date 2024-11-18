namespace GenialSchedule.Domain.Entities;

public class Store(string name,
    string logoUrl,
    string bannerUrl,
    string aboutDescription,
    string segment) : BaseEntity
{
    public string Name { get; } = name;
    public string LogoUrl { get; } = logoUrl;
    public string BannerUrl { get; } = bannerUrl;
    public string AboutDescription { get; } = aboutDescription;
    public string Segment { get; } = segment;

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