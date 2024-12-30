using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_AspNetUsers_SellerId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductUnitPrice",
                table: "OrderProducts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6d2982b9-f193-4372-b90a-d32006128c65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b582c30f-f39c-4070-82fa-58699265b922");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "69ffa5cb-6dae-4b73-b958-7e1ecc6c83d8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86dda00b-d0a8-4f29-b0b6-ac94a8652db1", "AQAAAAEAACcQAAAAEPWldbegPYtP3ukD1MrV6W9cxZoT1WN5XYX1x++l1XTWx3R4edQYrd+wd96PBJoSww==", "48fe648e-498a-42a2-b051-983b8e9c149c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64632494-3212-460a-a3fc-180b8a9b7de9", "AQAAAAEAACcQAAAAEB4t/+QA0uqdkFp15MVgl82WXv3f5oNJomqPt3VDAX84g9C6MlVYPezeuipG9ye54Q==", "42d507f2-4486-48ce-aacd-0ed8fe2fbb28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75fbbe1e-0417-4eba-96f3-f56772093230", "AQAAAAEAACcQAAAAEEcX4VP6R1v8bW7QVIAXIRRWeUbJBJAIISg95L3QyWoHmipdVZGFIcXGFHtVATSVmQ==", "e349d109-4e6c-4d5d-b629-a0a88f20bed0" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_AspNetUsers_SellerId",
                table: "OrderProducts",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_AspNetUsers_SellerId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductUnitPrice",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7c08cfe1-a352-4d1c-8d83-3d458cba4bcf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5a7ca12c-2b7f-4a67-a639-29363db7f701");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5d13b37c-aee4-4ea0-b137-45b33098d8f2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c76f8de-33ab-4b52-b0e9-bc9565b7071b", "AQAAAAEAACcQAAAAELDiqILFIT8NDgQw6vzcX9qXSCIGISLzBV8K0ZE9wWwFmzw4WgDlVVmSTTF9YfAXOA==", "61f03e88-474e-4ddb-9b04-8bdb6eb7bde0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dd59f09-b192-45a5-83f1-da05b772c614", "AQAAAAEAACcQAAAAEIT0D9N1nznqFzRoiyQSTPUACEqBHVT5pH1OUHNkc869k4yBH2iiqn18YZC24Yr4Sw==", "a805a0c8-d3cf-41df-9f81-065e700c7df4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5060733a-e661-4bca-ad31-7feefa64b2aa", "AQAAAAEAACcQAAAAELu47KAYky98qx6F0n7hQja4Ik+VSgW4u9jkFqHT1l0jfSLnE2VzjUOTSjHeZ1C7sQ==", "56e94e21-8409-4de9-afe4-8677355974e4" });

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
    }
}
