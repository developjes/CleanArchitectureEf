﻿namespace Example.Ecommerce.Domain.Entities.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}