using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetup.Api.Migrations
{
    public partial class add_config_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topico_Usuario_UsuarioId",
                table: "Topico");

            migrationBuilder.DropIndex(
                name: "IX_Topico_UsuarioId",
                table: "Topico");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Topico");

            migrationBuilder.AddColumn<int>(
                name: "ConfiguracionId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicoId",
                table: "Topico",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ConfiguracionId",
                table: "Usuario",
                column: "ConfiguracionId");

            migrationBuilder.CreateIndex(
                name: "IX_Topico_TopicoId",
                table: "Topico",
                column: "TopicoId");

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topico_Configuracion_TopicoId",
                table: "Topico");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Configuracion_ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Topico_TopicoId",
                table: "Topico");

            migrationBuilder.DropColumn(
                name: "ConfiguracionId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TopicoId",
                table: "Topico");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Topico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topico_UsuarioId",
                table: "Topico",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topico_Usuario_UsuarioId",
                table: "Topico",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
