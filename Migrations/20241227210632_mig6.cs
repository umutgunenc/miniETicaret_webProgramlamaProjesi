using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductUnitPrice",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductUnitPrice",
                table: "OrderProducts");

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
        }
    }
}
