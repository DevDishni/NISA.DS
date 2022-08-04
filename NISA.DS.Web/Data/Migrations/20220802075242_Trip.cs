using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NISA.DS.Web.Data.Migrations
{
    public partial class Trip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TripTypes_TriptypeId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TriptypeId",
                table: "Trips",
                newName: "TripTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TriptypeId",
                table: "Trips",
                newName: "IX_Trips_TripTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TripTypes_TripTypeId",
                table: "Trips",
                column: "TripTypeId",
                principalTable: "TripTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TripTypes_TripTypeId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripTypeId",
                table: "Trips",
                newName: "TriptypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TripTypeId",
                table: "Trips",
                newName: "IX_Trips_TriptypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TripTypes_TriptypeId",
                table: "Trips",
                column: "TriptypeId",
                principalTable: "TripTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
