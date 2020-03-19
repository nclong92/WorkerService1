using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerService1.Migrations
{
    public partial class addFieldToDarkSkyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDisplay",
                table: "DarkSkyWeathers");

            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "DarkSkyWeathers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "DarkSkyWeathers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "DarkSkyWeathers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "DarkSkyDailyWeathers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "DarkSkyDailyWeathers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "DarkSkyWeathers");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "DarkSkyDailyWeathers");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "DarkSkyDailyWeathers");

            migrationBuilder.AlterColumn<string>(
                name: "longitude",
                table: "DarkSkyWeathers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "DarkSkyWeathers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeDisplay",
                table: "DarkSkyWeathers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
