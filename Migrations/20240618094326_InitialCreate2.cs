using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_test2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    BookAuthorsId = table.Column<int>(type: "int", nullable: false),
                    BookAuthorsId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.BookAuthorsId, x.BookAuthorsId1 });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_BookAuthorsId",
                        column: x => x.BookAuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BookAuthorsId1",
                        column: x => x.BookAuthorsId1,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BookAuthorsId1",
                table: "AuthorBook",
                column: "BookAuthorsId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");
        }
    }
}
