using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_SellerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SellerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "ProductId", "OrderId", "SellerId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e28c84ba-2d0f-41da-a106-7178eb198d4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b9fff554-cde4-4218-9612-4c22c32d102f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5d6485d3-4ac9-4d67-bff2-a4c87b380021");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4f88e59-a404-443f-b2f1-2a8ecfb071bc", "AQAAAAEAACcQAAAAEPn2AHhpmaXReL7GUdzRQ2BBw0OG/Szj9wn3lSg08lDwOp+I7uU72tL5MagX4u5u4A==", "ae091175-43ff-401e-8357-a881658c5f0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "868be387-cba6-41ad-8f47-ed5ee48b1907", "AQAAAAEAACcQAAAAEASK/kq3p3Q/FqotTie8SxVQ0bXAR38Yb6X61gtLWg0eae9u4oTwmico1ExfJkInFg==", "8e9ed056-5b39-4212-b13d-7f721b1f5bdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e15088a1-c22f-4cfd-a29c-6049adb08a63", "AQAAAAEAACcQAAAAEIU3zBeZVTNhqwmHs9zu5SEIPdlRGAPuuRszDwZHsLJBlvQYSp96fXzqtx/XLHsfAg==", "3ec29e8a-e674-4782-82d8-1615cbf311c8" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_SellerId",
                table: "OrderProducts",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_AspNetUsers_SellerId",
                table: "OrderProducts",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_AspNetUsers_SellerId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_SellerId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "OrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c54c9fcd-1981-4eed-8f55-a0765a4f42ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c99c0638-013f-406e-b655-af15245b5193");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4fa67c48-2588-4e9d-8a0e-9c6e342a0de3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a965ece-8fd2-465c-b1e0-efda50883f1e", "AQAAAAEAACcQAAAAEPdQTxzTpJGYtuisy+w9AVEblhnXOcLTHcDBX7hGJ1z7ClqQLGw3h6rm1mnoLCj4xQ==", "068fac10-68d0-4e7b-8336-867d6ea9481d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "207ddf6a-aadc-48f3-ba4a-acef399f74f9", "AQAAAAEAACcQAAAAEGKHmdDLIPlUy+ZxvZeHKjr2B03MTqUXdApZnrhPYe1+gylotS5/e/dTdoyb5JL4zA==", "061f84e2-a1f5-4e9d-ba60-d4ac95ef628c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e888d0e3-39b0-4b99-b1e8-6aeb1a7e7540", "AQAAAAEAACcQAAAAEBJ6KpSpVFhY/DsbXQxPkcNshJvX6QpfFHGQlS2+wkqsOvke4AJaHUR+t7M5ykvqZg==", "b5a12672-c31b-4d5f-b601-09ab19057861" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerId",
                table: "Orders",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_SellerId",
                table: "Orders",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
