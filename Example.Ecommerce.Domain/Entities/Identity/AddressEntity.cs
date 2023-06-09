﻿using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Identity;

public class AddressEntity : BaseDomainEntity
{
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Department { get; set; }
    public string? PostalCode { get; set; }
    public string? Username { get; set; }
    public string? Country { get; set; }
}