using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class SettingTablEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InfoTitle",
                table: "Settings",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfoTitle",
                table: "Settings");
        }
    }
}
