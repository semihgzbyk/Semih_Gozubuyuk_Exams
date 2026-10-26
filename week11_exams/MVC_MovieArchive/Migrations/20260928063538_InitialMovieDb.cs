using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_MovieArchive.Migrations
{
    /// <inheritdoc />
    public partial class InitialMovieDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Çağan Irmak", 2005, "Babam ve Oğlum" },
                    { 2, "Yavuz Turgul", 1996, "Eşkıya" },
                    { 3, "Nuri Bilge Ceylan", 2014, "Kış Uykusu" },
                    { 4, "Francis Ford Coppola", 1972, "The Godfather" },
                    { 5, "Quentin Tarantino", 1994, "Pulp Fiction" },
                    { 6, "Christopher Nolan", 2010, "Inception" },
                    { 7, "David Fincher", 1999, "Fight Club" },
                    { 8, "Christopher Nolan", 2014, "Interstellar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
