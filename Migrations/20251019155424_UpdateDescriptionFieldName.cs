using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class UpdateDescriptionFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Despriction",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Despriction",
                table: "Orders",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0defb1a0-5c0e-436d-94a2-4b6323fef2a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "01aa95f2-fb20-42df-bcac-5499442d919b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "57ee5c43-52a6-46c5-a389-c540f39b1a36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c9e6edb-7ab4-499b-8461-5956ac487604", "AQAAAAEAACcQAAAAEC5QfZEtk4CDJJYIDfUzyCz70XBuyQbNBmedDgbyWwkck8ZxdglfXdfiiXGnxb1L6g==", "7e3790a2-043d-436f-81f7-c5614ff433b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0823016a-9195-4be7-8435-d066bf41cbe6", "AQAAAAEAACcQAAAAEEDaUOIl2/ajLfZyM6Jw4F/k1b127BFwIKunONC8S3AknmU6igGd9jDySeDMiYNSFw==", "492ef5ae-80c6-48dc-b98b-60d082194a52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "046d0ccb-e083-4cb0-9aa6-2df41f09a61b", "AQAAAAEAACcQAAAAEA+DmLZmTPwGpDYC9iX/zvUUYD5f6rJPGDleYsmYBTiydaf68ftZyfaUK+tQ7cd6vA==", "67a25d44-738f-4d7b-bff3-bcf6011ee86a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Despriction");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "Despriction");

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
        }
    }
}
