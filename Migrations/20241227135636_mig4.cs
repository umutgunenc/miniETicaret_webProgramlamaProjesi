using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b1d8c3ca-3792-46be-b1f0-17c4410c7506");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fb3b0ac1-b34f-4f1a-af23-29d02c0460fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0880b278-6e8b-47b8-b519-df60d721ebf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b581f8b-82b7-4853-a4b4-d554552a9feb", "AQAAAAEAACcQAAAAEKOvuw8Tk0DFnpup910PMTlhzBhGgbRTJneSQxotyI55ST768f+oZ7CIJg4dSifgVg==", "97ce9865-93c0-41ef-905e-17f39fd8541f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65b34b2e-7049-4343-be07-7dcb834a2bf7", "AQAAAAEAACcQAAAAEP8cPepCmqsXauB6mDPT0stMGGtLwAwuALLFDGZQIJnzvcqA8KNbx+VnQ8axiyj1hg==", "1b6f1b42-a828-4a84-8ab7-78b294a83310" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26abc7ef-f57f-4f21-bc4d-798d338618c8", "AQAAAAEAACcQAAAAEEI3bj10M3JCpQ1tThMCkwWLpBXaPbTxvV+uXxvVH5u3JG+ZxIhENaPak2ymRvnHWw==", "731d0e1b-307d-4e70-8e6d-b3570626fd34" });
        }
    }
}
