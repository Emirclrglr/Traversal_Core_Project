using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class remove_reservation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsT_AspNetUsers_AppUserId",
                table: "ReservationsT");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsT_Destinations_DestinationId",
                table: "ReservationsT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationsT",
                table: "ReservationsT");

            migrationBuilder.RenameTable(
                name: "ReservationsT",
                newName: "ReservationT");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationsT_DestinationId",
                table: "ReservationT",
                newName: "IX_ReservationT_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationsT_AppUserId",
                table: "ReservationT",
                newName: "IX_ReservationT_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationT",
                table: "ReservationT",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationT_AspNetUsers_AppUserId",
                table: "ReservationT",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationT_Destinations_DestinationId",
                table: "ReservationT",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationT_AspNetUsers_AppUserId",
                table: "ReservationT");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationT_Destinations_DestinationId",
                table: "ReservationT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationT",
                table: "ReservationT");

            migrationBuilder.RenameTable(
                name: "ReservationT",
                newName: "ReservationsT");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationT_DestinationId",
                table: "ReservationsT",
                newName: "IX_ReservationsT_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationT_AppUserId",
                table: "ReservationsT",
                newName: "IX_ReservationsT_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationsT",
                table: "ReservationsT",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsT_AspNetUsers_AppUserId",
                table: "ReservationsT",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsT_Destinations_DestinationId",
                table: "ReservationsT",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
