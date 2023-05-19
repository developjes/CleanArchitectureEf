using System.Runtime.Serialization;

namespace Example.Ecommerce.Domain.Enums.Parametrization;

public enum EProduct : byte
{
    [EnumMember(Value = "Inactive State")]
    Inactive = 1,
    [EnumMember(Value = "Active State")]
    Active = 2
}

public enum EOrder : byte
{
    [EnumMember(Value = "Pending State")]
    Pending,
    [EnumMember(Value = "Completed State")]
    Completed,
    [EnumMember(Value = "Sent State")]
    Sent,
    [EnumMember(Value = "Error State")]
    Error
}