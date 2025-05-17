using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbOperationsForEfCore.Migrations
{
    /// <inheritdoc />
    public partial class updatetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currencyin",
                table: "Currencies",
                newName: "Title");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "INDIAN INR", "INR" },
                    { 2, "Dollar", "Dollar" },
                    { 3, "Euro", "Euro" },
                    { 4, "Dinar", "Dinar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_Bookid",
                table: "BookPrices",
                column: "Bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Books_Bookid",
                table: "BookPrices",
                column: "Bookid",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Books_Bookid",
                table: "BookPrices");

            migrationBuilder.DropIndex(
                name: "IX_BookPrices_Bookid",
                table: "BookPrices");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Currencies",
                newName: "Currencyin");
        }
    }
}
