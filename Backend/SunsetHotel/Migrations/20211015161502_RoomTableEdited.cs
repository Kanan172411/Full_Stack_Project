using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class RoomTableEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Rooms_RoomId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_RoomId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Features");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_RoomId",
                table: "Features",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Rooms_RoomId",
                table: "Features",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
