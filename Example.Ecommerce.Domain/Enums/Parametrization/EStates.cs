using System.ComponentModel;

namespace Example.Ecommerce.Domain.Enums.Parametrization;

public enum EAllStates : byte
{
    [Description("Inactive state")]
    Inactive = 1,
    [Description("Active state")]
    Active = 2,
    [Description("Pending state")]
    Pending = 3,
    [Description("Completed state")]
    Completed = 4,
    [Description("Sent state")]
    Sent = 5,
    [Description("Error state")]
    Error = 6
}

[DefaultValue(Active)]
public enum EProductState : byte
{
    [Description("Inactive")]
    Inactive = 1,
    [Description("Active")]
    Active = 2
}

[DefaultValue(Pending)]
public enum EOrderState : byte
{
    [Description("Pending")]
    Pending = 3,
    [Description("Completed")]
    Completed = 4,
    [Description("Sent")]
    Sent = 5,
    [Description("Error")]
    Error = 6
}