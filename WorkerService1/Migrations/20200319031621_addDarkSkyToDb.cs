using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerService1.Migrations
{
    public partial class addDarkSkyToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DarkSkyDailyWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<string>(nullable: true),
                    UserModified = table.Column<string>(nullable: true),
                    time = table.Column<long>(nullable: false),
                    timezone = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    sunriseTime = table.Column<long>(nullable: false),
                    sunsetTime = table.Column<long>(nullable: false),
                    moonPhase = table.Column<double>(nullable: false),
                    precipIntensity = table.Column<double>(nullable: false),
                    precipIntensityMax = table.Column<double>(nullable: false),
                    precipIntensityMaxTime = table.Column<long>(nullable: false),
                    precipProbability = table.Column<double>(nullable: false),
                    precipType = table.Column<string>(nullable: true),
                    temperatureHigh = table.Column<double>(nullable: false),
                    temperatureHighTime = table.Column<long>(nullable: false),
                    temperatureLow = table.Column<double>(nullable: false),
                    temperatureLowTime = table.Column<long>(nullable: false),
                    apparentTemperatureHigh = table.Column<double>(nullable: false),
                    apparentTemperatureHighTime = table.Column<long>(nullable: false),
                    apparentTemperatureLow = table.Column<double>(nullable: false),
                    apparentTemperatureLowTime = table.Column<long>(nullable: false),
                    dewPoint = table.Column<double>(nullable: false),
                    humidity = table.Column<double>(nullable: false),
                    pressure = table.Column<double>(nullable: false),
                    windSpeed = table.Column<double>(nullable: false),
                    windGust = table.Column<double>(nullable: false),
                    windGustTime = table.Column<long>(nullable: false),
                    windBearing = table.Column<double>(nullable: false),
                    cloudCover = table.Column<double>(nullable: false),
                    uvIndex = table.Column<int>(nullable: false),
                    uvIndexTime = table.Column<long>(nullable: false),
                    visibility = table.Column<double>(nullable: false),
                    ozone = table.Column<double>(nullable: false),
                    temperatureMin = table.Column<double>(nullable: false),
                    temperatureMinTime = table.Column<long>(nullable: false),
                    temperatureMax = table.Column<double>(nullable: false),
                    temperatureMaxTime = table.Column<long>(nullable: false),
                    apparentTemperatureMin = table.Column<double>(nullable: false),
                    apparentTemperatureMinTime = table.Column<long>(nullable: false),
                    apparentTemperatureMax = table.Column<double>(nullable: false),
                    apparentTemperatureMaxTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DarkSkyDailyWeathers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DarkSkyWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<string>(nullable: true),
                    UserModified = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    timezone = table.Column<string>(nullable: true),
                    time = table.Column<long>(nullable: false),
                    summary = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    precipIntensity = table.Column<double>(nullable: false),
                    precipProbability = table.Column<double>(nullable: false),
                    precipType = table.Column<string>(nullable: true),
                    temperature = table.Column<double>(nullable: false),
                    apparentTemperature = table.Column<double>(nullable: false),
                    dewPoint = table.Column<double>(nullable: false),
                    humidity = table.Column<double>(nullable: false),
                    windSpeed = table.Column<double>(nullable: false),
                    windGust = table.Column<double>(nullable: false),
                    windBearing = table.Column<double>(nullable: false),
                    cloudCover = table.Column<double>(nullable: false),
                    uvIndex = table.Column<double>(nullable: false),
                    visibility = table.Column<double>(nullable: false),
                    ozone = table.Column<double>(nullable: false),
                    TimeDisplay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DarkSkyWeathers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DarkSkyDailyWeathers");

            migrationBuilder.DropTable(
                name: "DarkSkyWeathers");
        }
    }
}
