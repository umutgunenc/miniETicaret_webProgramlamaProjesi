using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartCustomerId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartProductId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartCustomerId_CartProductId",
                table: "AspNetUsers",
                columns: new[] { "CartCustomerId", "CartProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_CartCustomerId_CartProductId",
                table: "AspNetUsers",
                columns: new[] { "CartCustomerId", "CartProductId" },
                principalTable: "Carts",
                principalColumns: new[] { "CustomerId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartCustomerId_CartProductId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartCustomerId_CartProductId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartCustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartProductId",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0565c7c9-3b63-4597-9d87-82541b2da020", "AQAAAAEAACcQAAAAEMmj8aaRJuTrBR9S6E2FpQpqvxFnHZIYiOLcYqjzM8CAqrcBWd64xtfPji6fBcuyUA==", "72165f10-07a3-47db-96d2-845797d99d53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a52bbed1-599d-4524-a967-644d0d6c455c", "AQAAAAEAACcQAAAAEGcogRM4znMivNb7lX5+ZpkAVrR9Qap69FMB6Mh/fNrj2WXNGJZTvvzfBuHZsH4LoQ==", "4acee7ea-7f9b-4ec1-bd73-653693f32ef6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c523a27-98b3-447e-82c4-2c078a579dea", "AQAAAAEAACcQAAAAEPVELg9qkBUzgmrt90cAl48QPKpyBrkkO+IDRDv5drkkw9MlCxdYqdII7GWgSL/s8Q==", "352043e1-09d9-482e-86ea-acb221028f45" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId",
                unique: true);
        }
    }
}
