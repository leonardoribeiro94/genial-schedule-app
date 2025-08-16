namespace GenialSchedule.Domain.Entities;

public sealed class Service : BaseEntity
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

    public string Name { get; } = default!;
    public string Description { get; }
    public decimal Price { get; }
    public string ImageServiceUrl { get; }
    public Guid StoreId { get; }
    public Store Store { get; } = default!;
}