using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeListAPI.Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Studios",
                newName: "StudioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Series",
                newName: "SeriesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Languages",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudioId",
                table: "Studios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "Series",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Languages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Id");
        }
    }
}
