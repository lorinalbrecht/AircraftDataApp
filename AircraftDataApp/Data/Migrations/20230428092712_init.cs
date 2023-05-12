using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftDataApp.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftType",
                columns: table => new
                {
                    IdAircraftType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftType", x => x.IdAircraftType);
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    IdAirline = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.IdAirline);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    IdAirport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportCodeShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportCodeLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.IdAirport);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    IdAircraft = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FsAircraftType = table.Column<int>(type: "int", nullable: false),
                    FsAirline = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.IdAircraft);
                    table.ForeignKey(
                        name: "FK_Aircraft_AircraftType_FsAircraftType",
                        column: x => x.FsAircraftType,
                        principalTable: "AircraftType",
                        principalColumn: "IdAircraftType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aircraft_Airline_FsAirline",
                        column: x => x.FsAirline,
                        principalTable: "Airline",
                        principalColumn: "IdAirline",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft_Airport",
                columns: table => new
                {
                    IdAircraftAirport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FsAircraft = table.Column<int>(type: "int", nullable: false),
                    FsAirport = table.Column<int>(type: "int", nullable: false),
                    DatePosition = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft_Airport", x => x.IdAircraftAirport);
                    table.ForeignKey(
                        name: "FK_Aircraft_Airport_Aircraft_FsAircraft",
                        column: x => x.FsAircraft,
                        principalTable: "Aircraft",
                        principalColumn: "IdAircraft",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aircraft_Airport_Airport_FsAirport",
                        column: x => x.FsAirport,
                        principalTable: "Airport",
                        principalColumn: "IdAirport",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_FsAircraftType",
                table: "Aircraft",
                column: "FsAircraftType");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_FsAirline",
                table: "Aircraft",
                column: "FsAirline");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_Airport_FsAircraft",
                table: "Aircraft_Airport",
                column: "FsAircraft");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_Airport_FsAirport",
                table: "Aircraft_Airport",
                column: "FsAirport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircraft_Airport");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "AircraftType");

            migrationBuilder.DropTable(
                name: "Airline");
        }
    }
}
