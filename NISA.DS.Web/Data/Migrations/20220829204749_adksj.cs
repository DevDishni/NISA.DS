using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NISA.DS.Web.Data.Migrations
{
    public partial class adksj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketType",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Trips");
        }
    }
}
