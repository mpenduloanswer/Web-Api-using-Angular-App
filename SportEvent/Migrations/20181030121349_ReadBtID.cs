using Microsoft.EntityFrameworkCore.Migrations;

namespace SportEvent.Migrations
{
    public partial class ReadBtID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_sports_SportID",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "IX_countries_SportID",
                table: "countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_countries_SportID",
                table: "countries",
                column: "SportID");

            migrationBuilder.AddForeignKey(
                name: "FK_countries_sports_SportID",
                table: "countries",
                column: "SportID",
                principalTable: "sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
