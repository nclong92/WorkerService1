using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerService1.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<string>(nullable: true),
                    UserModified = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    lon = table.Column<string>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    temp = table.Column<double>(nullable: false),
                    feels_like = table.Column<double>(nullable: false),
                    temp_min = table.Column<double>(nullable: false),
                    temp_max = table.Column<double>(nullable: false),
                    pressure = table.Column<double>(nullable: false),
                    humidity = table.Column<double>(nullable: false),
                    windspeed = table.Column<double>(nullable: false),
                    winddeg = table.Column<double>(nullable: false),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
