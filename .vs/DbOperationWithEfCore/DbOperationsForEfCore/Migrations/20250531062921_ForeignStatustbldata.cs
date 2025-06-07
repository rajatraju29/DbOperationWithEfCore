using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbOperationsForEfCore.Migrations
{
    /// <inheritdoc />
    public partial class ForeignStatustbldata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Statusid",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Statusid",
                table: "Books",
                column: "Statusid");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Statuses_Statusid",
                table: "Books",
                column: "Statusid",
                principalTable: "Statuses",
                principalColumn: "Statusid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Statuses_Statusid",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Statusid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Statusid",
                table: "Books");
        }
    }
}
