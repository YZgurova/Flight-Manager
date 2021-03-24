using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight_Manager.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFrom = table.Column<string>(nullable: false),
                    LocationTo = table.Column<string>(nullable: true),
                    Takeoff = table.Column<DateTime>(nullable: false),
                    Landing = table.Column<DateTime>(nullable: false),
                    PlaneId = table.Column<string>(nullable: true),
                    planeType = table.Column<int>(nullable: false),
                    PilotName = table.Column<string>(nullable: true),
                    CountOfFreePosition = table.Column<int>(nullable: false),
                    BusinessClassFreePositions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
