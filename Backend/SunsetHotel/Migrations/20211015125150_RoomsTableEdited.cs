using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class RoomsTableEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Room_RoomId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomCategories_CategoriesId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatureRelation_RoomFeatures_RoomFeatureId",
                table: "RoomFeatureRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatureRelation_Room_RoomId",
                table: "RoomFeatureRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomImages_Room_RoomId",
                table: "RoomImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomFeatureRelation",
                table: "RoomFeatureRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "RoomFeatureRelation",
                newName: "RoomFeatureRelations");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFeatureRelation_RoomId",
                table: "RoomFeatureRelations",
                newName: "IX_RoomFeatureRelations_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFeatureRelation_RoomFeatureId",
                table: "RoomFeatureRelations",
                newName: "IX_RoomFeatureRelations_RoomFeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_CategoriesId",
                table: "Rooms",
                newName: "IX_Rooms_CategoriesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomFeatureRelations",
                table: "RoomFeatureRelations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Rooms_RoomId",
                table: "Features",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatureRelations_RoomFeatures_RoomFeatureId",
                table: "RoomFeatureRelations",
                column: "RoomFeatureId",
                principalTable: "RoomFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatureRelations_Rooms_RoomId",
                table: "RoomFeatureRelations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomImages_Rooms_RoomId",
                table: "RoomImages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_CategoriesId",
                table: "Rooms",
                column: "CategoriesId",
                principalTable: "RoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Rooms_RoomId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatureRelations_RoomFeatures_RoomFeatureId",
                table: "RoomFeatureRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatureRelations_Rooms_RoomId",
                table: "RoomFeatureRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomImages_Rooms_RoomId",
                table: "RoomImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_CategoriesId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomFeatureRelations",
                table: "RoomFeatureRelations");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "RoomFeatureRelations",
                newName: "RoomFeatureRelation");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_CategoriesId",
                table: "Room",
                newName: "IX_Room_CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFeatureRelations_RoomId",
                table: "RoomFeatureRelation",
                newName: "IX_RoomFeatureRelation_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFeatureRelations_RoomFeatureId",
                table: "RoomFeatureRelation",
                newName: "IX_RoomFeatureRelation_RoomFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomFeatureRelation",
                table: "RoomFeatureRelation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Room_RoomId",
                table: "Features",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomCategories_CategoriesId",
                table: "Room",
                column: "CategoriesId",
                principalTable: "RoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatureRelation_RoomFeatures_RoomFeatureId",
                table: "RoomFeatureRelation",
                column: "RoomFeatureId",
                principalTable: "RoomFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatureRelation_Room_RoomId",
                table: "RoomFeatureRelation",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomImages_Room_RoomId",
                table: "RoomImages",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
