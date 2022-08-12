using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NISA.DS.Web.Data.Migrations
{
    public partial class AstronautRatingprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Astronauts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Astronauts");
        }
    }
}
