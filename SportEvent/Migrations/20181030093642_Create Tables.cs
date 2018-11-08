using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEvent.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sports",
                columns: table => new
                {
                    SportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SportName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true),
                    SportID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_countries_sports_SportID",
                        column: x => x.SportID,
                        principalTable: "sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TournamentName = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tournaments", x => x.TournamentID);
                    table.ForeignKey(
                        name: "FK_tournaments_countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TournamentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_events_tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countries_SportID",
                table: "countries",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_events_TournamentID",
                table: "events",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_tournaments_CountryID",
                table: "tournaments",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "tournaments");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "sports");
        }
    }
}
