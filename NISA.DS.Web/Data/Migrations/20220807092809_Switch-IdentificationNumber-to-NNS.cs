using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NISA.DS.Web.Data.Migrations
{
    public partial class SwitchIdentificationNumbertoNNS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "Passengers",
                newName: "NNS");

            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "Astronauts",
                newName: "NNS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NNS",
                table: "Passengers",
                newName: "IdentificationNumber");

            migrationBuilder.RenameColumn(
                name: "NNS",
                table: "Astronauts",
                newName: "IdentificationNumber");
        }
    }
}
