using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jornada.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Tree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Destino",
                newName: "TextoDescritivo");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Destino",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destino",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destino_Foto",
                        column: x => x.DestinoId,
                        principalTable: "Destino",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foto_DestinoId",
                table: "Foto",
                column: "DestinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destino");

            migrationBuilder.RenameColumn(
                name: "TextoDescritivo",
                table: "Destino",
                newName: "Foto");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Destino",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
