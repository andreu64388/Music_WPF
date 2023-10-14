using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicAPI.Migrations
{
	/// <inheritdoc />
	public partial class update : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Genres",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Genres", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Tracks",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Title = table.Column<string>(type: "text", nullable: false),
					CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					Img = table.Column<string>(type: "text", nullable: false),
					Source = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tracks", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false),
					Img = table.Column<string>(type: "text", nullable: false),
					Email = table.Column<string>(type: "text", nullable: false),
					Password = table.Column<string>(type: "text", nullable: false),
					UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					Role = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

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

			migrationBuilder.CreateTable(
				name: "Libraries",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					UserId = table.Column<int>(type: "integer", nullable: false),
					TrackId = table.Column<int>(type: "integer", nullable: false),
					PlayCount = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Libraries", x => x.Id);
					table.ForeignKey(
						name: "FK_Libraries_Tracks_TrackId",
						column: x => x.TrackId,
						principalTable: "Tracks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Libraries_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TrackUser",
				columns: table => new
				{
					TracksId = table.Column<int>(type: "integer", nullable: false),
					UsersId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TrackUser", x => new { x.TracksId, x.UsersId });
					table.ForeignKey(
						name: "FK_TrackUser_Tracks_TracksId",
						column: x => x.TracksId,
						principalTable: "Tracks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TrackUser_Users_UsersId",
						column: x => x.UsersId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_GenreTrack_TracksId",
				table: "GenreTrack",
				column: "TracksId");

			migrationBuilder.CreateIndex(
				name: "IX_Libraries_TrackId",
				table: "Libraries",
				column: "TrackId");

			migrationBuilder.CreateIndex(
				name: "IX_Libraries_UserId",
				table: "Libraries",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_TrackUser_UsersId",
				table: "TrackUser",
				column: "UsersId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GenreTrack");

			migrationBuilder.DropTable(
				name: "Libraries");

			migrationBuilder.DropTable(
				name: "TrackUser");

			migrationBuilder.DropTable(
				name: "Genres");

			migrationBuilder.DropTable(
				name: "Tracks");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}