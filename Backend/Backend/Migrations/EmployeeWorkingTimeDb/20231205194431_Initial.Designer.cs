﻿// <auto-generated />
using System;
using Backend.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations.EmployeeWorkingTimeDb
{
    [DbContext(typeof(EmployeeWorkingTimeDbContext))]
    [Migration("20231205194431_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Entities.CardScanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Clock")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardScans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Clock = new DateTime(2012, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 2,
                            Clock = new DateTime(2012, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 3,
                            Clock = new DateTime(2012, 1, 1, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 4,
                            Clock = new DateTime(2012, 1, 1, 8, 40, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000002"
                        },
                        new
                        {
                            Id = 5,
                            Clock = new DateTime(2012, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000002"
                        },
                        new
                        {
                            Id = 6,
                            Clock = new DateTime(2012, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 7,
                            Clock = new DateTime(2012, 1, 2, 5, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 8,
                            Clock = new DateTime(2012, 1, 2, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 9,
                            Clock = new DateTime(2012, 1, 2, 22, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001"
                        },
                        new
                        {
                            Id = 10,
                            Clock = new DateTime(2012, 1, 2, 4, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000002"
                        },
                        new
                        {
                            Id = 11,
                            Clock = new DateTime(2012, 1, 2, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000002"
                        });
                });

            modelBuilder.Entity("Backend.Models.Entities.WorkScheduleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BeginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WorkDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkSchedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeginTime = new DateTime(2012, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001",
                            EndTime = new DateTime(2012, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDate = new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BeginTime = new DateTime(2012, 1, 2, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000001",
                            EndTime = new DateTime(2012, 1, 2, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDate = new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BeginTime = new DateTime(2012, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000002",
                            EndTime = new DateTime(2012, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDate = new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            BeginTime = new DateTime(2012, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = "000000002",
                            EndTime = new DateTime(2012, 1, 2, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDate = new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
