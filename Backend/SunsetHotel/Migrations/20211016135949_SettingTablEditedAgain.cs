using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class SettingTablEditedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InfoTitle",
                table: "Settings",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InfoTitle",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
