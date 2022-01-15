using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.API.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    DateEvent = table.Column<string>(type: "TEXT", nullable: true),
                    Theme = table.Column<string>(type: "TEXT", nullable: true),
                    NumPeople = table.Column<int>(type: "INTEGER", nullable: false),
                    Batch = table.Column<string>(type: "TEXT", nullable: true),
                    UrlImage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
