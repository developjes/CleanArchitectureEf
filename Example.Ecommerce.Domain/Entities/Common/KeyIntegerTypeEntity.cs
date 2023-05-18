namespace Example.Ecommerce.Domain.Entities.Common
{
    public abstract class KeyIntegerTypeEntity : BaseAuditableEntity
    {
        public int Id { get; set; }
    }
}