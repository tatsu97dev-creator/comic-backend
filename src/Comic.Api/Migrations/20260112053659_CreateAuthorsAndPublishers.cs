using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comic.Api.Migrations
{
    public partial class CreateAuthorsAndPublishers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Works", table: "Works");

            migrationBuilder.RenameTable(name: "Works", newName: "Work");

            migrationBuilder.AddPrimaryKey(name: "PK_Work", table: "Work", column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Work", table: "Work");

            migrationBuilder.RenameTable(name: "Work", newName: "Works");

            migrationBuilder.AddPrimaryKey(name: "PK_Works", table: "Works", column: "Id");
        }
    }
}
