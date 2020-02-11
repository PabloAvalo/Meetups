using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Notificacion");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Topico",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Topico");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Notificacion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
