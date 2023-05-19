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
                name: "Petition");

            migrationBuilder.EnsureSchema(
                name: "Parametrization");

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                schema: "Parametrization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Identification Type Name"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "Identification Type Description"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Parametrization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "State Name"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "State Description"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadLine",
                schema: "Petition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line Identification Number"),
                    FirstName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line First Name"),
                    SecondName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Head Line Second Name"),
                    FirstLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line First Last Name"),
                    SecondLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Head Line Second Last Name"),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false, comment: "Head Line Birthdate"),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey Identification Type Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadLine_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalSchema: "Parametrization",
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiary",
                schema: "Petition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line Identification Number"),
                    FirstName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Beneficiary First Name"),
                    SecondName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Beneficiary Second Name"),
                    FirstLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Beneficiary First Last Name"),
                    SecondLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Beneficiary Second Last Name"),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey Identification Type Table"),
                    HeadLineIdId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey HeadLine Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiary_HeadLine_HeadLineIdId",
                        column: x => x.HeadLineIdId,
                        principalSchema: "Petition",
                        principalTable: "HeadLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiary_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalSchema: "Parametrization",
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Petition",
                schema: "Petition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Radicate = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Petition Radicate"),
                    Expired = table.Column<bool>(type: "bit", nullable: false, comment: "Petition Expired"),
                    HeadLineId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey HeadLine Table"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey State Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Petition_HeadLine_HeadLineId",
                        column: x => x.HeadLineId,
                        principalSchema: "Petition",
                        principalTable: "HeadLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Petition_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Parametrization",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "IdentificationType",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documento de identidad nacional", "Cedula de ciudadania", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documento de identidad nacional", "Tarjeta de identidad", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documento de identidad internacional", "Cedula de extrageria", null }
                });

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "State",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactivo", "Inactive", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activo", "Active", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activo2", "Active2", null }
                });

            migrationBuilder.InsertData(
                schema: "Petition",
                table: "HeadLine",
                columns: new[] { "Id", "Birthdate", "CreateAt", "FirstLastName", "FirstName", "IdentificationNumber", "IdentificationTypeId", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[] { 1, new DateTime(1993, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solarte", "Jhon", "1143953449", 1, "Vasquez", "Eddier", null });

            migrationBuilder.InsertData(
                schema: "Petition",
                table: "HeadLine",
                columns: new[] { "Id", "Birthdate", "CreateAt", "FirstLastName", "FirstName", "IdentificationNumber", "IdentificationTypeId", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[] { 2, new DateTime(1991, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz", "Paola", "1063811659", 3, "Manzano", "Andrea", null });

            migrationBuilder.InsertData(
                schema: "Petition",
                table: "HeadLine",
                columns: new[] { "Id", "Birthdate", "CreateAt", "FirstLastName", "FirstName", "IdentificationNumber", "IdentificationTypeId", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[] { 3, new DateTime(1969, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz", "Araceli", "1111111111", 3, null, null, null });

            migrationBuilder.InsertData(
                schema: "Petition",
                table: "Beneficiary",
                columns: new[] { "Id", "CreateAt", "FirstLastName", "FirstName", "HeadLineIdId", "IdentificationNumber", "IdentificationTypeId", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasquez", "Francy", 1, "31179933", 1, "Rodriguez", "Eliana", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz", "Araceli", 2, "1063811659", 1, "Manzano", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Petition",
                table: "Petition",
                columns: new[] { "Id", "CreateAt", "Expired", "HeadLineId", "Radicate", "UpdateAt", "StateId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "202", null, 2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "2355", null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "321", null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_HeadLineIdId",
                schema: "Petition",
                table: "Beneficiary",
                column: "HeadLineIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_IdentificationTypeId",
                schema: "Petition",
                table: "Beneficiary",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadLine_IdentificationTypeId",
                schema: "Petition",
                table: "HeadLine",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Petition_HeadLineId",
                schema: "Petition",
                table: "Petition",
                column: "HeadLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Petition_StateId",
                schema: "Petition",
                table: "Petition",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                schema: "Parametrization",
                table: "State",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiary",
                schema: "Petition");

            migrationBuilder.DropTable(
                name: "Petition",
                schema: "Petition");

            migrationBuilder.DropTable(
                name: "HeadLine",
                schema: "Petition");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Parametrization");

            migrationBuilder.DropTable(
                name: "IdentificationType",
                schema: "Parametrization");
        }
    }
}
