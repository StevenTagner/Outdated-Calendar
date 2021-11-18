using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAppPage.Migrations
{
    public partial class InitialCreatea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "EventObject",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EventObject");
        }
    }
}
