using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKcheck.Migrations
{
    public partial class Libb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WorldRating",
                table: "Rating",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "OurRating",
                table: "Rating",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLiber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLiber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndRead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBook = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdPage = table.Column<int>(type: "INTEGER", nullable: false),
                    PageId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdUserLiber = table.Column<int>(type: "INTEGER", nullable: false),
                    UserLiberId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndRead_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndRead_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndRead_UserLiber_UserLiberId",
                        column: x => x.UserLiberId,
                        principalTable: "UserLiber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinishRead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBook = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdPage = table.Column<int>(type: "INTEGER", nullable: false),
                    PageId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdUserLiber = table.Column<int>(type: "INTEGER", nullable: false),
                    UserLiberId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinishRead_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinishRead_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinishRead_UserLiber_UserLiberId",
                        column: x => x.UserLiberId,
                        principalTable: "UserLiber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NowRead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBook = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdPage = table.Column<int>(type: "INTEGER", nullable: false),
                    PageId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdUserLiber = table.Column<int>(type: "INTEGER", nullable: false),
                    UserLiberId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NowRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NowRead_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NowRead_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NowRead_UserLiber_UserLiberId",
                        column: x => x.UserLiberId,
                        principalTable: "UserLiber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WantRead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBook = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdPage = table.Column<int>(type: "INTEGER", nullable: false),
                    PageId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdUserLiber = table.Column<int>(type: "INTEGER", nullable: false),
                    UserLiberId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WantRead_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WantRead_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WantRead_UserLiber_UserLiberId",
                        column: x => x.UserLiberId,
                        principalTable: "UserLiber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndRead_BookId",
                table: "EndRead",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_EndRead_PageId",
                table: "EndRead",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_EndRead_UserLiberId",
                table: "EndRead",
                column: "UserLiberId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishRead_BookId",
                table: "FinishRead",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishRead_PageId",
                table: "FinishRead",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishRead_UserLiberId",
                table: "FinishRead",
                column: "UserLiberId");

            migrationBuilder.CreateIndex(
                name: "IX_NowRead_BookId",
                table: "NowRead",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_NowRead_PageId",
                table: "NowRead",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_NowRead_UserLiberId",
                table: "NowRead",
                column: "UserLiberId");

            migrationBuilder.CreateIndex(
                name: "IX_WantRead_BookId",
                table: "WantRead",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_WantRead_PageId",
                table: "WantRead",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_WantRead_UserLiberId",
                table: "WantRead",
                column: "UserLiberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndRead");

            migrationBuilder.DropTable(
                name: "FinishRead");

            migrationBuilder.DropTable(
                name: "NowRead");

            migrationBuilder.DropTable(
                name: "WantRead");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "UserLiber");

            migrationBuilder.AlterColumn<decimal>(
                name: "WorldRating",
                table: "Rating",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "OurRating",
                table: "Rating",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
