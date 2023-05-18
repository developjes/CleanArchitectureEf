using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Example.Ecommerce.Persistence.Migrations
{
    public partial class AddNetTopologySuitFieldLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "northwindconnect");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                schema: "northwindconnect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Identification Type Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "Identification Type Description", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "State",
                schema: "northwindconnect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "State Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "State Description", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "HeadLine",
                schema: "northwindconnect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdentificationNumber = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line Identification Number", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line First Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Head Line Second Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line First Last Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Head Line Second Last Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false, comment: "Head Line Birthdate"),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey Identification Type Table"),
                    Location = table.Column<Point>(type: "point", nullable: false, comment: "Head Line Location"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadLine_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalSchema: "northwindconnect",
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Beneficiary",
                schema: "northwindconnect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdentificationNumber = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Head Line Identification Number", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Beneficiary First Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Beneficiary Second Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Beneficiary First Last Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondLastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Beneficiary Second Last Name", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey Identification Type Table"),
                    HeadLineIdId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey HeadLine Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiary_HeadLine_HeadLineIdId",
                        column: x => x.HeadLineIdId,
                        principalSchema: "northwindconnect",
                        principalTable: "HeadLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiary_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalSchema: "northwindconnect",
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Petition",
                schema: "northwindconnect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Table Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Radicate = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "Petition Radicate", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expired = table.Column<ulong>(type: "bit", nullable: false, comment: "Petition Expired"),
                    HeadLineId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey HeadLine Table"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey State Table"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Petition_HeadLine_HeadLineId",
                        column: x => x.HeadLineId,
                        principalSchema: "northwindconnect",
                        principalTable: "HeadLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Petition_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "northwindconnect",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "IdentificationType",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documento de identidad nacional", "Cedula de ciudadania", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documento de identidad nacional", "Tarjeta de identidad", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documento de identidad internacional", "Cedula de extrageria", null }
                });

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "State",
                columns: new[] { "Id", "CreateAt", "Description", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactivo", "Inactive", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activo", "Active", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activo2", "Active2", null }
                });

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "HeadLine",
                columns: new[] { "Id", "Birthdate", "CreateAt", "FirstLastName", "FirstName", "IdentificationNumber", "IdentificationTypeId", "Location", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[] { 1, new DateTime(1993, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solarte", "Jhon", "1143953449", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (18.4839233 -69.9388777)"), "Vasquez", "Eddier", null });

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "HeadLine",
                columns: new[] { "Id", "Birthdate", "CreateAt", "FirstLastName", "FirstName", "IdentificationNumber", "IdentificationTypeId", "Location", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[] { 2, new DateTime(1991, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz", "Paola", "1063811659", 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (18.4839233 -69.9388777)"), "Manzano", "Andrea", null });

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "HeadLine",
                columns: new[] { "Id", "Birthdate", "CreateAt", "FirstLastName", "FirstName", "IdentificationNumber", "IdentificationTypeId", "Location", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[] { 3, new DateTime(1969, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz", "Araceli", "1111111111", 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (18.4839233 -69.9388777)"), null, null, null });

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "Beneficiary",
                columns: new[] { "Id", "CreateAt", "FirstLastName", "FirstName", "HeadLineIdId", "IdentificationNumber", "IdentificationTypeId", "SecondLastName", "SecondName", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasquez", "Francy", 1, "31179933", 1, "Rodriguez", "Eliana", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diaz", "Araceli", 2, "1063811659", 1, "Manzano", null, null }
                });

            migrationBuilder.InsertData(
                schema: "northwindconnect",
                table: "Petition",
                columns: new[] { "Id", "CreateAt", "Expired", "HeadLineId", "Radicate", "UpdateAt", "StateId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0ul, 1, "202", null, 2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0ul, 2, "2355", null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0ul, 2, "321", null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_HeadLineIdId",
                schema: "northwindconnect",
                table: "Beneficiary",
                column: "HeadLineIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_IdentificationTypeId",
                schema: "northwindconnect",
                table: "Beneficiary",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadLine_IdentificationTypeId",
                schema: "northwindconnect",
                table: "HeadLine",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Petition_HeadLineId",
                schema: "northwindconnect",
                table: "Petition",
                column: "HeadLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Petition_StateId",
                schema: "northwindconnect",
                table: "Petition",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                schema: "northwindconnect",
                table: "State",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiary",
                schema: "northwindconnect");

            migrationBuilder.DropTable(
                name: "Petition",
                schema: "northwindconnect");

            migrationBuilder.DropTable(
                name: "HeadLine",
                schema: "northwindconnect");

            migrationBuilder.DropTable(
                name: "State",
                schema: "northwindconnect");

            migrationBuilder.DropTable(
                name: "IdentificationType",
                schema: "northwindconnect");
        }
    }
}
