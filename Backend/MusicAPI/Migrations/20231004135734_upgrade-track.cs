using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
	/// <inheritdoc />
	public partial class upgradetrack : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "TrackUser");

			migrationBuilder.AddColumn<int>(
				name: "UserId",
				table: "Tracks",
				type: "integer",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_Tracks_UserId",
				table: "Tracks",
				column: "UserId");

			migrationBuilder.AddForeignKey(
				name: "FK_Tracks_Users_UserId",
				table: "Tracks",
				column: "UserId",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Tracks_Users_UserId",
				table: "Tracks");

			migrationBuilder.DropIndex(
				name: "IX_Tracks_UserId",
				table: "Tracks");

			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Tracks");

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
				name: "IX_TrackUser_UsersId",
				table: "TrackUser",
				column: "UsersId");
		}
	}
}