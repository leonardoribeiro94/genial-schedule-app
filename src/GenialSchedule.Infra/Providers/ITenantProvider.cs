namespace GenialSchedule.Infra.Providers
{
    public interface ITenantProvider
    {
        Guid TenantId { get; }
    }
}