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
                name: "Ecommerce");

            migrationBuilder.EnsureSchema(
                name: "Parametrization");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Ecommerce",
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
                name: "Product",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Product Name"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", maxLength: 100, precision: 10, scale: 2, nullable: false, comment: "Product price"),
                    Description = table.Column<string>(type: "nvarchar(4000)", unicode: false, maxLength: 4000, nullable: true, comment: "Product description"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Product rating"),
                    Stock = table.Column<int>(type: "int", nullable: false, comment: "Product stock"),
                    Seller = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Product seller"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "Product ForeignKey State Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Ecommerce",
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
                name: "ProductImage",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: false, comment: "ProductImage url"),
                    PublicCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "ProductImage PublicCode"),
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
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Parametrization");
        }
    }
}
