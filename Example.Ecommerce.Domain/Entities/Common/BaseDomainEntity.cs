namespace Example.Ecommerce.Domain.Entities.Common
{
    public abstract class BaseDomainEntity
    {
        #region Primary Key Table

        public int Id { get; set; }

        #endregion Primary Key Table

        #region Audit fields table

        public DateTime CreateAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? LastModifiedBy { get; set; }

        #endregion Audit fields table
    }
}