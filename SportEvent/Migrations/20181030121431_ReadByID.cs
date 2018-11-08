using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEvent.Migrations
{
    public partial class ReadByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var ReadSportByID = "CREATE PROCEDURE [dbo].[ReadSportByID] @SportID int AS SELECT SportID, SportName FROM sports WHERE SportID = @SportID ";
            var ReadCountryByID = "CREATE PROCEDURE [dbo].[ReadCountryByID] @CountryID int AS SELECT  CountryName,SportID FROM countries WHERE CountryID = @CountryID ";
            var ReadEventByID = "CREATE PROCEDURE [dbo].[ReadEventByID] @EventID int AS SELECT EventID, EventName,DateCreated,TournamentID FROM events WHERE EventID = @EventID ";
            var ReadTournamentByID = "CREATE PROCEDURE [dbo].[ReadTournamentByID] @TournamentID int AS SELECT TournamentID, TournamentName,CountryID FROM tournaments WHERE TournamentID = @TournamentID ";
            //var ReadSportByID = "CREATE PROCEDURE [dbo].[ReadSportByID] @SportID int AS SELECT ID, SportName FROM sports WHERE SportID = @SportID ";

            migrationBuilder.Sql(ReadSportByID);
            migrationBuilder.Sql(ReadCountryByID);
            migrationBuilder.Sql(ReadEventByID);
            migrationBuilder.Sql(ReadTournamentByID);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
