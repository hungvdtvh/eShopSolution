using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1330fab-ac03-4d0e-9887-ffe7d76584b1"),
                column: "ConcurrencyStamp",
                value: "efa4cde5-bbfd-4aef-b919-93b983b2d01a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f8ff17f5-b3a7-4af1-bdd5-44d02750508a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f9ac96c-0a2f-4df6-b7e8-2196a4994906", "AQAAAAEAACcQAAAAEA1+Ifxc+pfof7isgGZa+LSA0WFB973VxEeGzOl2Ky3ebWj0T407snJIfl3vSq4Xow==" });

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
    }
}
