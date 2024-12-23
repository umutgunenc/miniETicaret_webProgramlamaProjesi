using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e85f9a0b-86f9-4646-9bea-28d012408eb9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "18f1a188-d8e4-4469-9172-1b95fbb5dc15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "dd1b40fc-33d4-4793-9571-f3f555a6751e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "0565c7c9-3b63-4597-9d87-82541b2da020", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEMmj8aaRJuTrBR9S6E2FpQpqvxFnHZIYiOLcYqjzM8CAqrcBWd64xtfPji6fBcuyUA==", "+905300000000", "72165f10-07a3-47db-96d2-845797d99d53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "a52bbed1-599d-4524-a967-644d0d6c455c", "SELLER@GMAIL.COM", "SELLER", "AQAAAAEAACcQAAAAEGcogRM4znMivNb7lX5+ZpkAVrR9Qap69FMB6Mh/fNrj2WXNGJZTvvzfBuHZsH4LoQ==", "+905300000001", "4acee7ea-7f9b-4ec1-bd73-653693f32ef6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6c523a27-98b3-447e-82c4-2c078a579dea", "CUSTOMER@GMAIL.COM", "CUSTOMER", "AQAAAAEAACcQAAAAEPVELg9qkBUzgmrt90cAl48QPKpyBrkkO+IDRDv5drkkw9MlCxdYqdII7GWgSL/s8Q==", "+905300000002", "352043e1-09d9-482e-86ea-acb221028f45" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "afac624a-17e0-4072-bec3-3d6cc3babe2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c5b6a92f-a19a-42ce-9adb-9917483f776d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "67f17333-8b85-4f30-a0c4-b2ac9224cc51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "22daee76-7680-423b-a20f-491cb188ed2e", null, null, "AQAAAAEAACcQAAAAECe7LQxBtuF9FGgvtmrXGO27z/Ve3hoIwQuOyFzavnXmM9FLzQYpN6mpQ2ZPiFqZMA==", "05300000000", "d54a93a5-2d88-4ac8-a5fe-128e43f09a46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "933af752-67ac-4d5a-9943-bd054a7dab71", null, null, "AQAAAAEAACcQAAAAEH40wkwr45sCrve2vsTf26CXJu+i3UX6NBT9fp+9Rv9kqGMo9ifuLKj9umbY298gZA==", "05300000001", "a89a1114-4e08-49d9-8efd-58bebe25f6bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "0da34c5d-2c89-42a7-aeb7-ddec7dbb8a92", null, null, "AQAAAAEAACcQAAAAEOsXejFZHnlEogW7DLViLNJF4ogF6OkVoiy9uNCzlCyCdX0lZokE7fHQaXU9u51I3g==", "05300000002", "ab358f53-a175-4966-b566-506e012b10e9" });
        }
    }
}
