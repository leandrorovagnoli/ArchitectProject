using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitectProject.Infrastructure.Migrations
{
    public partial class CustomerFieldUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Customer",
                type: "varchar(150)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }
    }
}
