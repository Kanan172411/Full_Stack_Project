using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class RoomTableEditedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_CategoriesId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CategoriesId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomCategoryId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId",
                principalTable: "RoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomCategoryId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CategoriesId",
                table: "Rooms",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_CategoriesId",
                table: "Rooms",
                column: "CategoriesId",
                principalTable: "RoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
