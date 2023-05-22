using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "Parametrization");

            migrationBuilder.EnsureSchema(
                name: "Ecommerce");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Address address"),
                    City = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Address City"),
                    Department = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Address Department"),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Address PostalCode"),
                    Username = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Address Username"),
                    Country = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Address Country"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Parametrization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Category Name"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Parametrization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Country Name"),
                    Iso2 = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Country Iso2"),
                    Iso3 = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Country Iso3"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderAddress",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderAddress address"),
                    City = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderAddress City"),
                    Department = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderAddress Department"),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderAddress PostalCode"),
                    Username = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderAddress Username"),
                    Country = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderAddress Country"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    ShoppingCartMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ShoppingCartItem ShoppingCartMasterId"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Parametrization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "State Name"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "State Description"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "ShoppingCartItem Product"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "ShoppingCartItem price"),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "ShoppingCartItem amount"),
                    Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "ShoppingCartItem Image"),
                    Category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "ShoppingCartItem Category"),
                    Stock = table.Column<int>(type: "int", nullable: false, comment: "ShoppingCartItem stock"),
                    ShoppingCartMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ShoppingCartItem ShoppingCartMasterId"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "shoppingCartItem ProductId"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "shoppingCartItem ForeignKey ShoppingCart Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "Ecommerce",
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Order BuyerName"),
                    BuyerUsername = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Order BuyerUsername"),
                    SubTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Order SubTotal"),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Order Total"),
                    Tax = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Order Tax"),
                    ShippingPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Order ShippingPrice"),
                    ClientSecret = table.Column<string>(type: "nvarchar(4000)", unicode: false, maxLength: 4000, nullable: false, comment: "OrderItem ClientSecret"),
                    StripeApiKey = table.Column<string>(type: "nvarchar(4000)", unicode: false, maxLength: 4000, nullable: false, comment: "Order StripeApiKey"),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(4000)", unicode: false, maxLength: 4000, nullable: false, comment: "OrderItem PaymentIntentId"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "Order ForeignKey State Table"),
                    OrderAddressId = table.Column<int>(type: "int", nullable: false, comment: "Order ForeignKey OrderAddress Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderAddress_OrderAddressId",
                        column: x => x.OrderAddressId,
                        principalSchema: "Ecommerce",
                        principalTable: "OrderAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Parametrization",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Product Name"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Product price"),
                    Description = table.Column<string>(type: "nvarchar(4000)", unicode: false, maxLength: 4000, nullable: true, comment: "Product description"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Product rating"),
                    Stock = table.Column<int>(type: "int", nullable: false, comment: "Product stock"),
                    Seller = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Product seller"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "Product ForeignKey State Table"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Product ForeignKey Category Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Parametrization",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Parametrization",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "OrderItem price"),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "OrderItem Amount"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "OrderItem ProductName"),
                    ImageUrl = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: false, comment: "orderItem ImageUrl"),
                    ProductItemId = table.Column<int>(type: "int", nullable: false, comment: "orderItem ProductItemId"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "OrderIdItem ForeignKey Order Table"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "OrderIdItem ForeignKey Product Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Ecommerce",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Ecommerce",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: false, comment: "ProductImage url"),
                    PublicCode = table.Column<string>(type: "varchar", unicode: false, nullable: false, comment: "ProductImage PublicCode"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "ProductImage ForeignKey Product Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Ecommerce",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Review Name"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Review rating"),
                    Comment = table.Column<string>(type: "nvarchar(4000)", unicode: false, maxLength: 4000, nullable: true, comment: "Review comment"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Review ForeignKey Product Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Ecommerce",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "HR", "Human Resource" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Telephone", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24", "2f720227-3b1a-4f93-b903-f58b7c6e5417", "developjes@gmail.com", false, true, "Solarte", false, null, "Jhon", null, null, "AQAAAAEAACcQAAAAEMxOmA+z7VusdsgQWgF0DqYEx0psTSZttrV4crjA8qgJ9c3Hku1Rx3Fk44ARiyyDnA==", "1234567890", false, "099fcf83-9992-4d1e-bccd-3c70debabe25", null, false, "JES" },
                    { "b74ddd14-6340-4840-95c2-db579863843e", 0, "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d", "864adedf-0c91-4e64-a64f-fd7c6d0f45d4", "juan.perez@gmail.com", false, true, "Perez", false, null, "Juan", null, null, "AQAAAAEAACcQAAAAEBtqzKN9NgbXF3g01MmMaxGodZHIjDBj4pIQL1kxlFFQOFOnv8CsPXGkxGS3NWfT5w==", "98563434534", false, "183032ff-489e-4b6e-abdc-f89a9610690d", null, false, "juan.perez" }
                });

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "State",
                columns: new[] { "Id", "CreateAt", "CreatedBy", "Description", "LastModifiedBy", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Inactive state", null, "Inactive", null },
                    { 2, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Active state", null, "Active", null },
                    { 3, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Pending state", null, "Pending", null },
                    { 4, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Completed state", null, "Completed", null },
                    { 5, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Sent state", null, "Sent", null },
                    { 6, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Error state", null, "Error", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db579863843e" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderAddressId",
                schema: "Ecommerce",
                table: "Order",
                column: "OrderAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_StateId",
                schema: "Ecommerce",
                table: "Order",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Ecommerce",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "Ecommerce",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Ecommerce",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StateId",
                schema: "Ecommerce",
                table: "Product",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                schema: "Ecommerce",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                schema: "Ecommerce",
                table: "Review",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                schema: "Ecommerce",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "ProductImage",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "ShoppingCart",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "OrderAddress",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Parametrization");
        }
    }
}
