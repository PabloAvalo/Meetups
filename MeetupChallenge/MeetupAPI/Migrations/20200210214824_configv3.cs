using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class configv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topico_Configuracions_TopicoId",
                table: "Topico");

            migrationBuilder.DropIndex(
                name: "IX_Topico_TopicoId",
                table: "Topico");

            migrationBuilder.DropColumn(
                name: "TopicoId",
                table: "Topico");

            migrationBuilder.DropColumn(
                name: "TopicoId",
                table: "Configuracions");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Configuracions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Configuracions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Configuracions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configuracions_UsuarioId",
                table: "Configuracions",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuracions_Usuario_UsuarioId",
                table: "Configuracions",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuracions_Usuario_UsuarioId",
                table: "Configuracions");

            migrationBuilder.DropIndex(
                name: "IX_Configuracions_UsuarioId",
                table: "Configuracions");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Configuracions");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Configuracions");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Configuracions");

            migrationBuilder.AddColumn<int>(
                name: "TopicoId",
                table: "Topico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicoId",
                table: "Configuracions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Topico_TopicoId",
                table: "Topico",
                column: "TopicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topico_Configuracions_TopicoId",
                table: "Topico",
                column: "TopicoId",
                principalTable: "Configuracions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
