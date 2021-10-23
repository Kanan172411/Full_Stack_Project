using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class RoomCommentsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 300, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomComments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomComments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomComments_AppUserId",
                table: "RoomComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomComments_RoomId",
                table: "RoomComments",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomComments");
        }
    }
}
