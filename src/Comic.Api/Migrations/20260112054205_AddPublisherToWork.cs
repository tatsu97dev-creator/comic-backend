using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comic.Api.Migrations
{
    public partial class AddPublisherToWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PublisherId",
                table: "Work",
                type: "bigint",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "PublisherId", table: "Work");
        }
    }
}
