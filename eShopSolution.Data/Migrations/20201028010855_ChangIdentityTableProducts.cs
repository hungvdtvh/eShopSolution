using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangIdentityTableProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"),
                column: "ConcurrencyStamp",
                value: "6973224c-84a0-46de-8d45-c2f261be38e2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8be6010f-3817-4993-a4c9-199892bf6956", "AQAAAAEAACcQAAAAELFoCkn4+7fWXOKbR9npUHyMdG0upjJYGXvuovQGEkc1zkaP5IJddfSutI9LzotpDw==" });

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
                values: new object[] { new DateTime(2020, 10, 28, 8, 8, 54, 443, DateTimeKind.Local).AddTicks(8745), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"),
                column: "ConcurrencyStamp",
                value: "39af673b-4719-4336-884d-6f9021cfb9b7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7344dd3-9fa1-4a86-8c93-2cf68b58dd49", "AQAAAAEAACcQAAAAEMZnG/UtVt8VWa2LHvSHDJJx/kX5x+S9jx1EMTcrPBbg5QOXyq/gu3vIduIveoMcQQ==" });

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
                values: new object[] { new DateTime(2020, 10, 27, 21, 46, 45, 127, DateTimeKind.Local).AddTicks(4776), 100000m });
        }
    }
}
