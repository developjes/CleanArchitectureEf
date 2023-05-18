namespace Example.Ecommerce.Domain.Entities.Common
{
    public abstract class BaseAuditableEntity
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}