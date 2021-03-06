﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkerService1.Models;

namespace WorkerService1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200319083527_addFieldToDarkSkyTable")]
    partial class addFieldToDarkSkyTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkerService1.Models.Weathers.WeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("feels_like")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("humidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("winddeg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("windspeed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("WorkerService2.Models.Weathers.DarkSkyDailyWeather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("apparentTemperatureHigh")
                        .HasColumnType("float");

                    b.Property<long>("apparentTemperatureHighTime")
                        .HasColumnType("bigint");

                    b.Property<double>("apparentTemperatureLow")
                        .HasColumnType("float");

                    b.Property<long>("apparentTemperatureLowTime")
                        .HasColumnType("bigint");

                    b.Property<double>("apparentTemperatureMax")
                        .HasColumnType("float");

                    b.Property<long>("apparentTemperatureMaxTime")
                        .HasColumnType("bigint");

                    b.Property<double>("apparentTemperatureMin")
                        .HasColumnType("float");

                    b.Property<long>("apparentTemperatureMinTime")
                        .HasColumnType("bigint");

                    b.Property<double>("cloudCover")
                        .HasColumnType("float");

                    b.Property<double>("dewPoint")
                        .HasColumnType("float");

                    b.Property<double>("humidity")
                        .HasColumnType("float");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<double>("moonPhase")
                        .HasColumnType("float");

                    b.Property<double>("ozone")
                        .HasColumnType("float");

                    b.Property<double>("precipIntensity")
                        .HasColumnType("float");

                    b.Property<double>("precipIntensityMax")
                        .HasColumnType("float");

                    b.Property<long>("precipIntensityMaxTime")
                        .HasColumnType("bigint");

                    b.Property<double>("precipProbability")
                        .HasColumnType("float");

                    b.Property<string>("precipType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("pressure")
                        .HasColumnType("float");

                    b.Property<string>("summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("sunriseTime")
                        .HasColumnType("bigint");

                    b.Property<long>("sunsetTime")
                        .HasColumnType("bigint");

                    b.Property<double>("temperatureHigh")
                        .HasColumnType("float");

                    b.Property<long>("temperatureHighTime")
                        .HasColumnType("bigint");

                    b.Property<double>("temperatureLow")
                        .HasColumnType("float");

                    b.Property<long>("temperatureLowTime")
                        .HasColumnType("bigint");

                    b.Property<double>("temperatureMax")
                        .HasColumnType("float");

                    b.Property<long>("temperatureMaxTime")
                        .HasColumnType("bigint");

                    b.Property<double>("temperatureMin")
                        .HasColumnType("float");

                    b.Property<long>("temperatureMinTime")
                        .HasColumnType("bigint");

                    b.Property<long>("time")
                        .HasColumnType("bigint");

                    b.Property<string>("timezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("uvIndex")
                        .HasColumnType("int");

                    b.Property<long>("uvIndexTime")
                        .HasColumnType("bigint");

                    b.Property<double>("visibility")
                        .HasColumnType("float");

                    b.Property<double>("windBearing")
                        .HasColumnType("float");

                    b.Property<double>("windGust")
                        .HasColumnType("float");

                    b.Property<long>("windGustTime")
                        .HasColumnType("bigint");

                    b.Property<double>("windSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DarkSkyDailyWeathers");
                });

            modelBuilder.Entity("WorkerService2.Models.Weathers.DarkSkyWeather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("apparentTemperature")
                        .HasColumnType("float");

                    b.Property<double>("cloudCover")
                        .HasColumnType("float");

                    b.Property<double>("dewPoint")
                        .HasColumnType("float");

                    b.Property<double>("humidity")
                        .HasColumnType("float");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<double>("ozone")
                        .HasColumnType("float");

                    b.Property<double>("precipIntensity")
                        .HasColumnType("float");

                    b.Property<double>("precipProbability")
                        .HasColumnType("float");

                    b.Property<string>("precipType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("temperature")
                        .HasColumnType("float");

                    b.Property<long>("time")
                        .HasColumnType("bigint");

                    b.Property<string>("timezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("uvIndex")
                        .HasColumnType("float");

                    b.Property<double>("visibility")
                        .HasColumnType("float");

                    b.Property<double>("windBearing")
                        .HasColumnType("float");

                    b.Property<double>("windGust")
                        .HasColumnType("float");

                    b.Property<double>("windSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DarkSkyWeathers");
                });

            modelBuilder.Entity("WorkerService2.Models.Weathers.FiveDaysWeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dt_txt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("feels_like")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("humidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("winddeg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("windspeed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FiveDaysWeathers");
                });
#pragma warning restore 612, 618
        }
    }
}
