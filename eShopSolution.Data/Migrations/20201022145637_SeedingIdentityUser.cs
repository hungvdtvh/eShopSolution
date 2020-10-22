using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedingIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"), "efa4cde5-bbfd-4aef-b919-93b983b2d01a", "Adminstrator role", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"), new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FristName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"), 0, "4f9ac96c-0a2f-4df6-b7e8-2196a4994906", new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "hungvd.tvh@gmail.com", true, "Hung", "Vo Duy", false, null, null, "Admin", "AQAAAAEAACcQAAAAEA1+Ifxc+pfof7isgGZa+LSA0WFB973VxEeGzOl2Ky3ebWj0T407snJIfl3vSq4Xow==", null, false, "", false, "Admin" });

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
                values: new object[] { new DateTime(2020, 10, 22, 21, 56, 37, 114, DateTimeKind.Local).AddTicks(1048), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"), new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"));

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
                values: new object[] { new DateTime(2020, 10, 22, 21, 35, 23, 635, DateTimeKind.Local).AddTicks(6704), 100000m });
        }
    }
}
