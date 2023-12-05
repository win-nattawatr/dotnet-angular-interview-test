using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations.EmployeeWorkingTimeDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardScans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clock = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardScans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CardScans",
                columns: new[] { "Id", "Clock", "EmployeeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 2, new DateTime(2012, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 3, new DateTime(2012, 1, 1, 17, 30, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 4, new DateTime(2012, 1, 1, 8, 40, 0, 0, DateTimeKind.Unspecified), "000000002" },
                    { 5, new DateTime(2012, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), "000000002" },
                    { 6, new DateTime(2012, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 7, new DateTime(2012, 1, 2, 5, 30, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 8, new DateTime(2012, 1, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 9, new DateTime(2012, 1, 2, 22, 30, 0, 0, DateTimeKind.Unspecified), "000000001" },
                    { 10, new DateTime(2012, 1, 2, 4, 0, 0, 0, DateTimeKind.Unspecified), "000000002" },
                    { 11, new DateTime(2012, 1, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), "000000002" }
                });

            migrationBuilder.InsertData(
                table: "WorkSchedules",
                columns: new[] { "Id", "BeginTime", "EmployeeId", "EndTime", "WorkDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "000000001", new DateTime(2012, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2012, 1, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "000000001", new DateTime(2012, 1, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2012, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "000000002", new DateTime(2012, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2012, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "000000002", new DateTime(2012, 1, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardScans");

            migrationBuilder.DropTable(
                name: "WorkSchedules");
        }
    }
}
