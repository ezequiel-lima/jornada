using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jornada.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destino_Foto",
                table: "Foto");

            migrationBuilder.AddForeignKey(
                name: "FK_Destino_Foto",
                table: "Foto",
                column: "DestinoId",
                principalTable: "Destino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destino_Foto",
                table: "Foto");

            migrationBuilder.AddForeignKey(
                name: "FK_Destino_Foto",
                table: "Foto",
                column: "DestinoId",
                principalTable: "Destino",
                principalColumn: "Id");
        }
    }
}
