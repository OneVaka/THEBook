using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKcheck.Migrations
{
    public partial class UserP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "Mail");

            migrationBuilder.AddColumn<string>(
                name: "Cookies",
                table: "Person",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cookies",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Person",
                newName: "Name");
        }
    }
}
