using System.ComponentModel;

namespace Example.Ecommerce.Domain.Enums.Parametrization
{
    public enum EState : byte
    {
        [Description("Inactive State")]
        Inactive = 1,

        [Description("Active State")]
        Active = 2
    }
}