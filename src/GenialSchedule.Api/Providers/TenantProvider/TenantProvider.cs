namespace GenialSchedule.Api.Providers.TenantProvider
{
    public class TenantProvider : ITenantProvider
    {
        public Guid TenantId { get; }

        public TenantProvider(IHttpContextAccessor accessor)
        {
            var http = accessor.HttpContext;
            if (http?.Request.Headers.TryGetValue("X-Tenant", out var values) == true &&
                Guid.TryParse(values.FirstOrDefault(), out var parsed))
                TenantId = parsed;
            else
                TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        }
    }
}