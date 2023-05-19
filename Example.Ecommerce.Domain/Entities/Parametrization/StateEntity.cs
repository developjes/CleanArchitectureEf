using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Parametrization;

public sealed class StateEntity : BaseDomainEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}