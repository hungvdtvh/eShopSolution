using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangFileNameSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"),
                column: "ConcurrencyStamp",
                value: "340e0fd8-f2df-4794-8cc4-5bad2474601d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cfc5c4e-e741-42cd-9c01-ee7854154825", "AQAAAAEAACcQAAAAEE7h43n8qKyhBJpfjhnreCsoch3CRVfUACNYAaUouIqebiDJII8HgcUeTByQV7DMJg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "OriginalPrice" },
                values: new object[] { new DateTime(2020, 10, 26, 15, 31, 0, 269, DateTimeKind.Local).AddTicks(6076), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"),
                column: "ConcurrencyStamp",
                value: "8b846fe6-9b24-4acd-ab5e-58a62d8a14b3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fc533e2-0636-48bf-8b54-7a37dfef2d03", "AQAAAAEAACcQAAAAEErSSJmgY4ZaxO8Qy6UDXqZzqgkBe2fSzICABdRO81OXIb5IOzV6qaY7fA1Yq2NSdg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "OriginalPrice" },
                values: new object[] { new DateTime(2020, 10, 24, 23, 39, 59, 821, DateTimeKind.Local).AddTicks(5298), 100000m });
        }
    }
}
