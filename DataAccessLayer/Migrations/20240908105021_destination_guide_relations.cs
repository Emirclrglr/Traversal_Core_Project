﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class destination_guide_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideId",
                table: "Destinations",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Destinations");
        }
    }
}
