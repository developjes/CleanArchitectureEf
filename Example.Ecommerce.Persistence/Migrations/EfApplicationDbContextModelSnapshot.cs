﻿// <auto-generated />
using System;
using Example.Ecommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Example.Ecommerce.Persistence.Migrations
{
    [DbContext(typeof(EfApplicationDbContext))]
    partial class EfApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1)
                        .HasComment("Table Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasColumnOrder(3)
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(6)
                        .HasComment("Usuario que crea el registro");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LastModifiedBy")
                        .HasComment("Usuario que por ultima vez actualizo el registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Category Name");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", "Ecommerce");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1)
                        .HasComment("Table Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasColumnOrder(10)
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(13)
                        .HasComment("Usuario que crea el registro");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("Description")
                        .HasColumnOrder(4)
                        .HasComment("Product description");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LastModifiedBy")
                        .HasComment("Usuario que por ultima vez actualizo el registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Product Name");

                    b.Property<decimal>("Price")
                        .HasMaxLength(100)
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Price")
                        .HasColumnOrder(3)
                        .HasComment("Product price");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("Rating")
                        .HasColumnOrder(5)
                        .HasComment("Product rating");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Seller")
                        .HasColumnOrder(7)
                        .HasComment("Product seller");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("Stock")
                        .HasColumnOrder(6)
                        .HasComment("Product stock");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("_stateId")
                        .HasColumnType("int")
                        .HasColumnName("StateId")
                        .HasColumnOrder(8)
                        .HasComment("Product ForeignKey State Table");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("_stateId");

                    b.ToTable("Product", "Ecommerce");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ProductImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1)
                        .HasComment("Table Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasColumnOrder(5)
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(8)
                        .HasComment("Usuario que crea el registro");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LastModifiedBy")
                        .HasComment("Usuario que por ultima vez actualizo el registro");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductId")
                        .HasColumnOrder(4)
                        .HasComment("ProductImage ForeignKey Product Table");

                    b.Property<string>("PublicCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("PublicCode")
                        .HasColumnOrder(3)
                        .HasComment("ProductImage PublicCode");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4000)")
                        .HasColumnName("Url")
                        .HasColumnOrder(2)
                        .HasComment("ProductImage url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage", "Ecommerce");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1)
                        .HasComment("Table Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasMaxLength(4000)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("Comment")
                        .HasColumnOrder(4)
                        .HasComment("Review comment");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasColumnOrder(6)
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(9)
                        .HasComment("Usuario que crea el registro");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LastModifiedBy")
                        .HasComment("Usuario que por ultima vez actualizo el registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Review Name");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("Rating")
                        .HasColumnOrder(3)
                        .HasComment("Review rating");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Review", "Ecommerce");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Parametrization.StateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1)
                        .HasComment("Table Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasColumnOrder(4)
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(7)
                        .HasComment("Usuario que crea el registro");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Description")
                        .HasColumnOrder(3)
                        .HasComment("State Description");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LastModifiedBy")
                        .HasComment("Usuario que por ultima vez actualizo el registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("State Name");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("State", "Parametrization");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "System",
                            Description = "Inactive state",
                            Name = "Inactive"
                        },
                        new
                        {
                            Id = 2,
                            CreateAt = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "System",
                            Description = "Active state",
                            Name = "Active"
                        },
                        new
                        {
                            Id = 3,
                            CreateAt = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "System",
                            Description = "Pending state",
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 4,
                            CreateAt = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "System",
                            Description = "Completed state",
                            Name = "Completed"
                        },
                        new
                        {
                            Id = 5,
                            CreateAt = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "System",
                            Description = "Sent state",
                            Name = "Sent"
                        },
                        new
                        {
                            Id = 6,
                            CreateAt = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "System",
                            Description = "Error state",
                            Name = "Error"
                        });
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ProductEntity", b =>
                {
                    b.HasOne("Example.Ecommerce.Domain.Entities.Ecommerce.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Example.Ecommerce.Domain.Entities.Parametrization.StateEntity", "State")
                        .WithMany("Products")
                        .HasForeignKey("_stateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Product_State_StateId");

                    b.Navigation("Category");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ProductImageEntity", b =>
                {
                    b.HasOne("Example.Ecommerce.Domain.Entities.Ecommerce.ProductEntity", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ReviewEntity", b =>
                {
                    b.HasOne("Example.Ecommerce.Domain.Entities.Ecommerce.ProductEntity", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Ecommerce.ProductEntity", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entities.Parametrization.StateEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
