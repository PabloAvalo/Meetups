using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class configidentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topico_Configuracion_TopicoId",
                table: "Topico");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Configuracion_ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion");

            migrationBuilder.RenameTable(
                name: "Configuracion",
                newName: "Configuracions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuracions",
                table: "Configuracions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topico_Configuracions_TopicoId",
                table: "Topico",
                column: "TopicoId",
                principalTable: "Configuracions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Configuracions_ConfiguracionId",
                table: "Usuario",
                column: "ConfiguracionId",
                principalTable: "Configuracions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topico_Configuracions_TopicoId",
                table: "Topico");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Configuracions_ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuracions",
                table: "Configuracions");

            migrationBuilder.RenameTable(
                name: "Configuracions",
                newName: "Configuracion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topico_Configuracion_TopicoId",
                table: "Topico",
                column: "TopicoId",
                principalTable: "Configuracion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Configuracion_ConfiguracionId",
                table: "Usuario",
                column: "ConfiguracionId",
                principalTable: "Configuracion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
