using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxBnB.Migrations
{
    /// <inheritdoc />
    public partial class DayInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRangeResId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayInfos_DateRanges_DateRangeResId",
                        column: x => x.DateRangeResId,
                        principalTable: "DateRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayInfos_DateRangeResId",
                table: "DayInfos",
                column: "DateRangeResId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayInfos");
        }
    }
}
