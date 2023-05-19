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
                name: "Review",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Review Name"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Review rating"),
                    Comment = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "Review comment"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    CreatedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Usuario que crea el registro"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Usuario que por ultima vez actualizo el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Product Name"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", maxLength: 100, precision: 10, scale: 2, nullable: false, comment: "Product price"),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "Product description"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Product rating"),
                    Stock = table.Column<int>(type: "int", nullable: false, comment: "Product stock"),
                    Seller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Product seller"),
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
                        name: "FK_Product_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Parametrization",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "State",
                columns: new[] { "Id", "CreateAt", "CreatedBy", "Description", "LastModifiedBy", "Name", "UpdateAt" },
                values: new object[] { 1, new DateTime(2023, 5, 19, 13, 25, 3, 963, DateTimeKind.Unspecified).AddTicks(9039), "System", "Inactive state", null, "Inactive", null });

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "State",
                columns: new[] { "Id", "CreateAt", "CreatedBy", "Description", "LastModifiedBy", "Name", "UpdateAt" },
                values: new object[] { 2, new DateTime(2023, 5, 19, 13, 25, 3, 963, DateTimeKind.Unspecified).AddTicks(9119), "System", "Active state", null, "Active", null });

            migrationBuilder.CreateIndex(
                name: "IX_Product_StateId",
                schema: "Ecommerce",
                table: "Product",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Ecommerce");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Parametrization");
        }
    }
}
