using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxBnB.Migrations
{
    /// <inheritdoc />
    public partial class DaysInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayInfos_DateRanges_DateRangeResId",
                table: "DayInfos");

            migrationBuilder.DropTable(
                name: "DateRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayInfos",
                table: "DayInfos");

            migrationBuilder.DropIndex(
                name: "IX_DayInfos_DateRangeResId",
                table: "DayInfos");

            migrationBuilder.DropColumn(
                name: "DateRangeResId",
                table: "DayInfos");

            migrationBuilder.RenameTable(
                name: "DayInfos",
                newName: "DaysInfo");

            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "DaysInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PropertyId",
                table: "DaysInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaysInfo",
                table: "DaysInfo",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DaysInfo",
                table: "DaysInfo");

            migrationBuilder.DropColumn(
                name: "Booked",
                table: "DaysInfo");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "DaysInfo");

            migrationBuilder.RenameTable(
                name: "DaysInfo",
                newName: "DayInfos");

            migrationBuilder.AddColumn<string>(
                name: "DateRangeResId",
                table: "DayInfos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayInfos",
                table: "DayInfos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DateRanges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateRanges", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayInfos_DateRangeResId",
                table: "DayInfos",
                column: "DateRangeResId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayInfos_DateRanges_DateRangeResId",
                table: "DayInfos",
                column: "DateRangeResId",
                principalTable: "DateRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
