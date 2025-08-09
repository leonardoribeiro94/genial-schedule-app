namespace GenialSchedule.Api.Providers.TenantProvider
{
    public interface ITenantProvider
    {
        Guid TenantId { get; }
    }
}