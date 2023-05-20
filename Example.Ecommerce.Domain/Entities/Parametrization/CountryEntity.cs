using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Parametrization;

public class CountryEntity : BaseDomainEntity
{
    public string? Name { get; set; }
    public string? Iso2 { get; set; }
    public string? Iso3 { get; set; }
}