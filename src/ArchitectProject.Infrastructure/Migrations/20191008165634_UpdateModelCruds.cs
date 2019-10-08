using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitectProject.Infrastructure.Migrations
{
    public partial class UpdateModelCruds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "GalleryItem",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "GalleryItem",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));
        }
    }
}
