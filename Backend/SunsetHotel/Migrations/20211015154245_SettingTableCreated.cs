using Microsoft.EntityFrameworkCore.Migrations;

namespace SunsetHotel.Migrations
{
    public partial class SettingTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OurServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Icon = table.Column<string>(maxLength: 70, nullable: false),
                    Desc = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoPart1 = table.Column<string>(maxLength: 50, nullable: false),
                    LogoPart2 = table.Column<string>(maxLength: 50, nullable: false),
                    WelcomeContent = table.Column<string>(maxLength: 150, nullable: false),
                    AboutBannerImage = table.Column<string>(maxLength: 80, nullable: true),
                    AboutTitle = table.Column<string>(maxLength: 200, nullable: false),
                    AboutDesc1 = table.Column<string>(maxLength: 1000, nullable: false),
                    AboutDesc2 = table.Column<string>(maxLength: 300, nullable: false),
                    OurbestRoomsTitle = table.Column<string>(maxLength: 150, nullable: false),
                    OurGalleryTitle = table.Column<string>(maxLength: 150, nullable: false),
                    TestimonialsTitle = table.Column<string>(maxLength: 150, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    PhoneNumber1 = table.Column<string>(maxLength: 60, nullable: false),
                    PhoneNumber2 = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 70, nullable: false),
                    AboutWelcomeContent = table.Column<string>(maxLength: 150, nullable: false),
                    GuestsStay = table.Column<int>(nullable: false),
                    RoomsCount = table.Column<int>(nullable: false),
                    Awards = table.Column<int>(nullable: false),
                    MealServed = table.Column<int>(nullable: false),
                    OurServicesTitle = table.Column<string>(maxLength: 150, nullable: false),
                    AboutEndBannerText = table.Column<string>(maxLength: 500, nullable: false),
                    ByWho = table.Column<string>(maxLength: 70, nullable: false),
                    RoomWelcomeContent = table.Column<string>(maxLength: 150, nullable: false),
                    BlogWelcomeContent = table.Column<string>(maxLength: 150, nullable: false),
                    ContactUsWelcomeContent = table.Column<string>(maxLength: 150, nullable: false),
                    BlogPostTitle = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurServices");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
