using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerService1.Migrations
{
    public partial class AddFiveDaysWeatherToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiveDaysWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<string>(nullable: true),
                    UserModified = table.Column<string>(nullable: true),
                    dt = table.Column<string>(nullable: true),
                    dt_txt = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    lon = table.Column<string>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    temp = table.Column<string>(nullable: true),
                    feels_like = table.Column<string>(nullable: true),
                    temp_min = table.Column<string>(nullable: true),
                    temp_max = table.Column<string>(nullable: true),
                    pressure = table.Column<string>(nullable: true),
                    humidity = table.Column<string>(nullable: true),
                    windspeed = table.Column<string>(nullable: true),
                    winddeg = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiveDaysWeathers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiveDaysWeathers");
        }
    }
}
