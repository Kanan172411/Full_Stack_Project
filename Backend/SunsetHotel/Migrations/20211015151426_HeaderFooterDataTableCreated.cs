using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class HeaderFooterDataTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeaderFooterDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Number = table.Column<string>(maxLength: 70, nullable: false),
                    LogoPart1 = table.Column<string>(maxLength: 50, nullable: false),
                    LogoPart2 = table.Column<string>(maxLength: 50, nullable: false),
                    Twitter = table.Column<string>(maxLength: 100, nullable: false),
                    Facebook = table.Column<string>(maxLength: 100, nullable: false),
                    Google = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderFooterDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeaderFooterDatas");
        }
    }
}
