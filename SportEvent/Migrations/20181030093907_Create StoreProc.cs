using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEvent.Migrations
{
    public partial class CreateStoreProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var CreateSport = "CREATE PROCEDURE [dbo].[InsertSport] @SportName VARCHAR(50)  AS INSERT INTO sports VALUES(@SportName)";
            var CreateCountry = "CREATE PROCEDURE [dbo].[InsertCountry] @CountryName VARCHAR(50),@SportID INT AS INSERT INTO countries VALUES(@CountryName,@SportID)";
            var CreateTournament = "CREATE PROCEDURE [dbo].[InsertTournament] @TournamentName VARCHAR(50), @CountryID INT AS INSERT INTO countries VALUES(@TournamentName, @CountryID)";
            var CreateEvent = "CREATE PROCEDURE [dbo].[InsertEvent] @EventName VARCHAR(50),@TournamentID int AS INSERT INTO countries VALUES(@EventName,Date.Now(),@TournamentID)";
            migrationBuilder.Sql(CreateSport);
            migrationBuilder.Sql(CreateCountry);
            migrationBuilder.Sql(CreateTournament);
            migrationBuilder.Sql(CreateEvent);

            var ReadallSport = "CREATE PROCEDURE [dbo].[ReadAllSport] AS BEGIN SELECT SportID, SportName FROM sports END";
            var ReadalCountry = "CREATE PROCEDURE [dbo].[ReadAllCountry] AS BEGIN SELECT CountryID, CountryName,SportID FROM countries END";
            var ReadallTournament = "CREATE PROCEDURE [dbo].[ReadAllTournament] AS BEGIN SELECT TournamentID,TournamentName,CountryID FROM tournaments END";
            var ReadallEvent = "CREATE PROCEDURE [dbo].[ReadAllEvent] AS BEGIN SELECT EventID,EventName,DateCreated,TournamentID FROM events END";

            migrationBuilder.Sql(ReadallSport);
            migrationBuilder.Sql(ReadalCountry);
            migrationBuilder.Sql(ReadallTournament);
            migrationBuilder.Sql(ReadallEvent);

            var DeleteSportByID = "CREATE PROCEDURE [dbo].[DeleteSportByID] @SportID INT  As DELETE  sports WHERE SportID = @SportID";
            var DeleteCountryByID = "CREATE PROCEDURE [dbo].[DeleteCountryByID] @CountryID INT  As DELETE  countries WHERE CountryID = @CountryID";
            var DeleteTournamentByID = "CREATE PROCEDURE [dbo].[DeleteTournamentByID] @TournamentID INT  As DELETE  tournaments WHERE TournamentID = @TournamentID";
            var DeleteEventByID = "CREATE PROCEDURE [dbo].[DeleteEventByID] @EventID INT  As DELETE  events WHERE EventID = @EventID";

            migrationBuilder.Sql(DeleteSportByID);
            migrationBuilder.Sql(DeleteCountryByID);
            migrationBuilder.Sql(DeleteTournamentByID);
            migrationBuilder.Sql(DeleteEventByID);

            var UpdateSport = "CREATE  PROCEDURE [dbo].[updateSport] @SportID int, @SportName varchar(50) AS UPDATE sports SET SportName = @SportName WHERE SportID = @SportID ";
            var UpdateCountry = "CREATE  PROCEDURE [dbo].[UpdateCountry] @CountryID int, @CountryName varchar(50) AS UPDATE countries SET CountryName = @CountryName WHERE CountryID = @CountryID ";
            var UpdateTournament = "CREATE  PROCEDURE [dbo].[UpdateTournament] @TournamentID int, @TournamentName varchar(50) AS UPDATE tournaments SET TournamentName = @TournamentName WHERE TournamentID = @TournamentID ";
            var UpdateEvent = "CREATE  PROCEDURE [dbo].[UpdateEvent] @EventID int, @EventName varchar(50) AS UPDATE events SET EventName = @EventName WHERE EventID = @EventID ";

            migrationBuilder.Sql(UpdateSport);
            migrationBuilder.Sql(UpdateCountry);
            migrationBuilder.Sql(UpdateTournament);
            migrationBuilder.Sql(UpdateEvent);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
