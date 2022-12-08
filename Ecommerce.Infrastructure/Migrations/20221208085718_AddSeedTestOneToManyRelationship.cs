using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    public partial class AddSeedTestOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCardId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");

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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1L, "Laptop", new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9691), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9695), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2L, "Phone", new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Country", "PhoneNumber", "TimeCreated", "TimeUpdated", "TrackingId", "UserId" },
                values: new object[] { 1L, "Nigeria", "+23456734567802", new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9883), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c9d0367a-315c-4c38-ae21-e6c0621f0215"), "1" });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "Quantity", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1L, 1L, 900.0, 2, new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9899), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9899), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "IsAvailable", "Name", "Price", "ProductImage", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1L, 1L, true, "Asus", 250.0, null, new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9834), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2L, 1L, true, "Dell", 350.0, null, new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9835), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9835), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3L, 1L, false, "MacBook", 550.0, null, new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9836), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4L, 2L, false, "IPhone11", 350.0, null, new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9840), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "ProductId", "Quantity", "ShoppingCartId", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1L, 1L, 2, "21", new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9921), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 12, 8, 8, 57, 18, 185, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 0, 0, 0, 0)) });

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
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingCartItems");

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

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCardId",
                table: "ShoppingCartItems",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
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
