using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
	/// <inheritdoc />
	public partial class update2 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlayCount",
				table: "Libraries");

			migrationBuilder.AddColumn<int>(
				name: "PlayCount",
				table: "Tracks",
				type: "integer",
				nullable: false,
				defaultValue: 0);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlayCount",
				table: "Tracks");

			migrationBuilder.AddColumn<int>(
				name: "PlayCount",
				table: "Libraries",
				type: "integer",
				nullable: false,
				defaultValue: 0);
		}
	}
}