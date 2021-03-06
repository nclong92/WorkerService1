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
    [Migration("20200316080010_AddFiveDaysWeatherToDB")]
    partial class AddFiveDaysWeatherToDB
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
