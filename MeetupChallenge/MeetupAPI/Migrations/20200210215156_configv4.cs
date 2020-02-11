using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class configv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Configuracions_ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ConfiguracionId",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfiguracionId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ConfiguracionId",
                table: "Usuario",
                column: "ConfiguracionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Configuracions_ConfiguracionId",
                table: "Usuario",
                column: "ConfiguracionId",
                principalTable: "Configuracions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
