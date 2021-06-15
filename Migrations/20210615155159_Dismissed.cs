using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDirectory.Migrations
{
    public partial class Dismissed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dismissed",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dismissed",
                table: "Employees");
        }
    }
}
