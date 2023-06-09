﻿using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> reviewBuilder)
    {
        #region Rule properties

        #region General config

        reviewBuilder.ToTable(name: "Review", schema: "Ecommerce");

        #endregion General config

        #region Fields

        reviewBuilder.Property(review => review.Name)
            .HasColumnName("Name")
            .HasComment("Review Name")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        reviewBuilder.Property(review => review.Rating)
            .HasColumnName("Rating")
            .HasComment("Review rating")
            .HasColumnType("int")
            .HasColumnOrder(3)
            .IsRequired(required: true);

        reviewBuilder.Property(review => review.Comment)
            .HasColumnName("Comment")
            .HasComment("Review comment")
            .HasColumnType("nvarchar")
            .HasMaxLength(4000)
            .HasColumnOrder(4)
            .IsUnicode(false)
            .IsRequired(required: false);

        reviewBuilder.Property(productImage => productImage.ProductId)
            .HasColumnName("ProductId")
            .HasComment("Review ForeignKey Product Table")
            .HasColumnType("int")
            .HasColumnOrder(5)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        reviewBuilder.HasOne(review => review.Product)
            .WithMany(product => product.Reviews)
            .HasForeignKey(review => review.ProductId);

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}