using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAppPage.Migrations
{
    public partial class InitialCreate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StringContainer_EventObject_EventObjectId1",
                table: "StringContainer");

            migrationBuilder.DropIndex(
                name: "IX_StringContainer_EventObjectId1",
                table: "StringContainer");

            migrationBuilder.DropColumn(
                name: "EventObjectId1",
                table: "StringContainer");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "EventObject",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "EventObject");

            migrationBuilder.AddColumn<int>(
                name: "EventObjectId1",
                table: "StringContainer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StringContainer_EventObjectId1",
                table: "StringContainer",
                column: "EventObjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StringContainer_EventObject_EventObjectId1",
                table: "StringContainer",
                column: "EventObjectId1",
                principalTable: "EventObject",
                principalColumn: "Id");
        }
    }
}
