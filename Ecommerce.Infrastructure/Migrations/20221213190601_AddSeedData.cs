using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SelectedAmount",
                table: "ShoppingCartItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "SelectedAmount",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ShoppingCartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ShoppingCartItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategory",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Country", "PhoneNumber", "TimeCreated", "TimeUpdated", "TrackingId", "UserId" },
                values: new object[] { 1L, "Nigeria", "+23456734567802", new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d58f2b7b-51a5-458d-b553-002b022b0a94"), "1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsAvailable", "Name", "Price", "ProductCategory", "ProductImage", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1L, true, "Asus", 250.0, 1, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6718), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2L, true, "Dell", 350.0, 1, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6719), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6719), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3L, false, "MacBook", 550.0, 1, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6721), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6720), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4L, false, "IPhone11", 350.0, 2, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6722), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5L, true, "Shirt", 60.0, 5, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6723), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6723), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6L, false, "Jacket", 35.0, 4, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6725), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6724), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7L, true, "Sweat Pants", 30.0, 7, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6725), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8L, true, "Trouser", 25.0, 6, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6728), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6727), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9L, false, "Shorts", 50.0, 3, null, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6728), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1L, 1L, 900.0, 3L, 2, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6993), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(6993), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "ProductId", "Quantity", "TimeCreated", "TimeUpdated", "TotalPrice" },
                values: new object[] { 1L, 1L, 2, new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(7008), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 13, 19, 6, 0, 764, DateTimeKind.Unspecified).AddTicks(7008), new TimeSpan(0, 0, 0, 0, 0)), 900.0 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ProductCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingCartItems",
                newName: "SelectedAmount");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "SelectedAmount");

            migrationBuilder.AddColumn<long>(
                name: "ShoppingCardId",
                table: "ShoppingCartItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TimeCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TimeUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCardId",
                table: "ShoppingCartItems",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_ShoppingCardId",
                table: "ShoppingCartItems",
                column: "ShoppingCardId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
