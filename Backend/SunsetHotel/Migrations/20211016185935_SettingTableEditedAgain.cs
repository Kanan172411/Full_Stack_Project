using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class SettingTableEditedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationTitle",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReservationWelcomeContent",
                table: "Settings",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ReservationWelcomeContent",
                table: "Settings");
        }
    }
}
