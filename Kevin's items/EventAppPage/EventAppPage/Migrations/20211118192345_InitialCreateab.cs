﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAppPage.Migrations
{
    public partial class InitialCreateab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "EventObject");

            migrationBuilder.CreateTable(
                name: "StringContainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringContainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringContainer_EventObject_EventObjectId",
                        column: x => x.EventObjectId,
                        principalTable: "EventObject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StringContainer_EventObjectId",
                table: "StringContainer",
                column: "EventObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StringContainer");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "EventObject",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
