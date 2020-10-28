using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeNameTableProductTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTraslations_Languges_LanguageId",
                table: "ProductTraslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTraslations_Products_ProductId",
                table: "ProductTraslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTraslations",
                table: "ProductTraslations");

            migrationBuilder.RenameTable(
                name: "ProductTraslations",
                newName: "ProductTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTraslations_ProductId",
                table: "ProductTranslations",
                newName: "IX_ProductTranslations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTraslations_LanguageId",
                table: "ProductTranslations",
                newName: "IX_ProductTranslations_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTranslations",
                table: "ProductTranslations",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Languges_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId",
                principalTable: "Languges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Products_ProductId",
                table: "ProductTranslations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Languges_LanguageId",
                table: "ProductTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Products_ProductId",
                table: "ProductTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTranslations",
                table: "ProductTranslations");

            migrationBuilder.RenameTable(
                name: "ProductTranslations",
                newName: "ProductTraslations");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTraslations",
                newName: "IX_ProductTraslations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTraslations",
                newName: "IX_ProductTraslations_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTraslations",
                table: "ProductTraslations",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTraslations_Languges_LanguageId",
                table: "ProductTraslations",
                column: "LanguageId",
                principalTable: "Languges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTraslations_Products_ProductId",
                table: "ProductTraslations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
