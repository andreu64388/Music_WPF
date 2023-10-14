using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
	/// <inheritdoc />
	public partial class addimage : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GenreTrack");

			migrationBuilder.RenameColumn(
				name: "Img",
				table: "Users",
				newName: "Image");

			migrationBuilder.RenameColumn(
				name: "Img",
				table: "Tracks",
				newName: "Image");

			migrationBuilder.AddColumn<int>(
				name: "Genre",
				table: "Tracks",
				type: "integer",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "GenreId",
				table: "Tracks",
				type: "integer",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Tracks_GenreId",
				table: "Tracks",
				column: "GenreId");

			migrationBuilder.AddForeignKey(
				name: "FK_Tracks_Genres_GenreId",
				table: "Tracks",
				column: "GenreId",
				principalTable: "Genres",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Tracks_Genres_GenreId",
				table: "Tracks");

			migrationBuilder.DropIndex(
				name: "IX_Tracks_GenreId",
				table: "Tracks");

			migrationBuilder.DropColumn(
				name: "Genre",
				table: "Tracks");

			migrationBuilder.DropColumn(
				name: "GenreId",
				table: "Tracks");

			migrationBuilder.RenameColumn(
				name: "Image",
				table: "Users",
				newName: "Img");

			migrationBuilder.RenameColumn(
				name: "Image",
				table: "Tracks",
				newName: "Img");

			migrationBuilder.CreateTable(
				name: "GenreTrack",
				columns: table => new
				{
					GenresId = table.Column<int>(type: "integer", nullable: false),
					TracksId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GenreTrack", x => new { x.GenresId, x.TracksId });
					table.ForeignKey(
						name: "FK_GenreTrack_Genres_GenresId",
						column: x => x.GenresId,
						principalTable: "Genres",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GenreTrack_Tracks_TracksId",
						column: x => x.TracksId,
						principalTable: "Tracks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_GenreTrack_TracksId",
				table: "GenreTrack",
				column: "TracksId");
		}
	}
}