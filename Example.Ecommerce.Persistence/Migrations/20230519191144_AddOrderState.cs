using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Ecommerce.Persistence.Migrations
{
    public partial class AddOrderState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                schema: "Parametrization",
                table: "State",
                columns: new[] { "Id", "CreateAt", "CreatedBy", "Description", "LastModifiedBy", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Pending state", null, "Pending", null },
                    { 4, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Completed state", null, "Completed", null },
                    { 5, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Sent state", null, "Sent", null },
                    { 6, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Error state", null, "Error", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 5, 19, 13, 25, 3, 963, DateTimeKind.Unspecified).AddTicks(9039));

            migrationBuilder.UpdateData(
                schema: "Parametrization",
                table: "State",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 5, 19, 13, 25, 3, 963, DateTimeKind.Unspecified).AddTicks(9119));
        }
    }
}
