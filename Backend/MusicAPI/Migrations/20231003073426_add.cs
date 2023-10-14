﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
	/// <inheritdoc />
	public partial class add : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "UpdateAt",
				table: "Users",
				type: "timestamp with time zone",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "UpdateAt",
				table: "Users",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone",
				oldNullable: true);
		}
	}
}