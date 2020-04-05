using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Migrations
{
    public partial class DBFix0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "76eadee9-6ec5-4139-8533-219a6fd94f2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER",
                column: "ConcurrencyStamp",
                value: "c31b7075-29f2-4540-840b-db63f866494d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "VELKOOBCHOD",
                column: "ConcurrencyStamp",
                value: "5d5c4bc8-d0dd-4422-9b7d-fd57d1f282df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINISTRATOR",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99199cdb-cb53-4bed-8616-feb75b3a3073", "AQAAAAEAACcQAAAAELPsqRqgBTilFR5D8fhscVzfF1ELaoefuOoJcNK7bvwQLiTEOm4MMfL1XFm4u2C0tg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7,
                column: "ParentID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 10,
                column: "ParentID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 13,
                column: "ParentID",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "f50dd2e4-bb8f-49bf-86b7-add2b2b6eb70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER",
                column: "ConcurrencyStamp",
                value: "ed07e4e3-7323-4dd8-9d16-0cbed2c1726e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "VELKOOBCHOD",
                column: "ConcurrencyStamp",
                value: "fde178b0-3459-4b00-aba0-96f1ec569caf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMINISTRATOR",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "750a38cf-5268-43a9-a73f-6af6f644ee16", "AQAAAAEAACcQAAAAEOwmIgtrPQs+6LVfB2+Jq9XgREVDK7mrd5ZJ4sB0eI/K4nuYUGETjd/UV9gUXoK5vQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7,
                column: "ParentID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 10,
                column: "ParentID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 13,
                column: "ParentID",
                value: 5);
        }
    }
}
