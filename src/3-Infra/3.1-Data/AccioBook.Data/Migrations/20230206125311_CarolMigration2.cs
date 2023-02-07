using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccioBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarolMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id_Genre",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Id_Genre",
                table: "Books",
                column: "Id_Genre");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genre_Id_Genre",
                table: "Books",
                column: "Id_Genre",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genre_Id_Genre",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Id_Genre",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Id_Genre",
                table: "Books");
        }
    }
}
