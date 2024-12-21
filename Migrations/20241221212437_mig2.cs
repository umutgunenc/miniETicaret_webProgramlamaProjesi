using Microsoft.EntityFrameworkCore.Migrations;

namespace miniETicaret.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nane",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Nane");
        }
    }
}
