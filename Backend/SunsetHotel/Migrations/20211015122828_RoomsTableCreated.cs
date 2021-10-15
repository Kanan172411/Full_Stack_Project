using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class RoomsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "RoomImages",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Galleries",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Features",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Desc = table.Column<string>(maxLength: 800, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoriesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "RoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeatureRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(nullable: false),
                    RoomFeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatureRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFeatureRelation_RoomFeatures_RoomFeatureId",
                        column: x => x.RoomFeatureId,
                        principalTable: "RoomFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFeatureRelation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_RoomId",
                table: "Features",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_CategoriesId",
                table: "Room",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureRelation_RoomFeatureId",
                table: "RoomFeatureRelation",
                column: "RoomFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureRelation_RoomId",
                table: "RoomFeatureRelation",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Room_RoomId",
                table: "Features",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomImages_Room_RoomId",
                table: "RoomImages",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Room_RoomId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomImages_Room_RoomId",
                table: "RoomImages");

            migrationBuilder.DropTable(
                name: "RoomFeatureRelation");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages");

            migrationBuilder.DropIndex(
                name: "IX_Features_RoomId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomImages");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Features");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "RoomImages",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Galleries",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70,
                oldNullable: true);
        }
    }
}
