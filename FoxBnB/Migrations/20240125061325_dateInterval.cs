using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxBnB.Migrations
{
    /// <inheritdoc />
    public partial class dateInterval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateRanges_Properties_PropertyId",
                table: "DateRanges");

            migrationBuilder.DropIndex(
                name: "IX_DateRanges_PropertyId",
                table: "DateRanges");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyId",
                table: "DateRanges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PropertyId",
                table: "DateRanges",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_DateRanges_PropertyId",
                table: "DateRanges",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateRanges_Properties_PropertyId",
                table: "DateRanges",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
