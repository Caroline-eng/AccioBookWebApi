using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccioBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class acciobook2023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Users_UserId",
                table: "Access");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreSearch_Genre_GenreId",
                table: "GenreSearch");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreSearch_Users_UserId",
                table: "GenreSearch");

            migrationBuilder.DropIndex(
                name: "IX_Access_UserId",
                table: "Access");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreSearch",
                table: "GenreSearch");

            migrationBuilder.DropIndex(
                name: "IX_GenreSearch_GenreId",
                table: "GenreSearch");

            migrationBuilder.DropIndex(
                name: "IX_GenreSearch_UserId",
                table: "GenreSearch");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Access");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "GenreSearch");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GenreSearch");

            migrationBuilder.RenameTable(
                name: "GenreSearch",
                newName: "GenresSearch");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Editions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenresSearch",
                table: "GenresSearch",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Access_Id_User",
                table: "Access",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_GenresSearch_Id_Genre",
                table: "GenresSearch",
                column: "Id_Genre");

            migrationBuilder.CreateIndex(
                name: "IX_GenresSearch_Id_User",
                table: "GenresSearch",
                column: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Users_Id_User",
                table: "Access",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenresSearch_Genre_Id_Genre",
                table: "GenresSearch",
                column: "Id_Genre",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenresSearch_Users_Id_User",
                table: "GenresSearch",
                column: "Id_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Users_Id_User",
                table: "Access");

            migrationBuilder.DropForeignKey(
                name: "FK_GenresSearch_Genre_Id_Genre",
                table: "GenresSearch");

            migrationBuilder.DropForeignKey(
                name: "FK_GenresSearch_Users_Id_User",
                table: "GenresSearch");

            migrationBuilder.DropIndex(
                name: "IX_Access_Id_User",
                table: "Access");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenresSearch",
                table: "GenresSearch");

            migrationBuilder.DropIndex(
                name: "IX_GenresSearch_Id_Genre",
                table: "GenresSearch");

            migrationBuilder.DropIndex(
                name: "IX_GenresSearch_Id_User",
                table: "GenresSearch");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Editions");

            migrationBuilder.RenameTable(
                name: "GenresSearch",
                newName: "GenreSearch");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Books",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Access",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenreId",
                table: "GenreSearch",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "GenreSearch",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreSearch",
                table: "GenreSearch",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Access_UserId",
                table: "Access",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSearch_GenreId",
                table: "GenreSearch",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSearch_UserId",
                table: "GenreSearch",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Users_UserId",
                table: "Access",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSearch_Genre_GenreId",
                table: "GenreSearch",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSearch_Users_UserId",
                table: "GenreSearch",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
