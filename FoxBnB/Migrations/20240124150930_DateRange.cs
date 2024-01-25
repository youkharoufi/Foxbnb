using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxBnB.Migrations
{
    /// <inheritdoc />
    public partial class DateRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateRange_Properties_PropertyId",
                table: "DateRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateRange",
                table: "DateRange");

            migrationBuilder.RenameTable(
                name: "DateRange",
                newName: "DateRanges");

            migrationBuilder.RenameIndex(
                name: "IX_DateRange_PropertyId",
                table: "DateRanges",
                newName: "IX_DateRanges_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateRanges",
                table: "DateRanges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateRanges_Properties_PropertyId",
                table: "DateRanges",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateRanges_Properties_PropertyId",
                table: "DateRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateRanges",
                table: "DateRanges");

            migrationBuilder.RenameTable(
                name: "DateRanges",
                newName: "DateRange");

            migrationBuilder.RenameIndex(
                name: "IX_DateRanges_PropertyId",
                table: "DateRange",
                newName: "IX_DateRange_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateRange",
                table: "DateRange",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateRange_Properties_PropertyId",
                table: "DateRange",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
