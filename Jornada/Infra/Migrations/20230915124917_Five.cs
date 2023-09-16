using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jornada.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Declaracao");

            migrationBuilder.AddColumn<Guid>(
                name: "DeclaracaoId",
                table: "Foto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_DeclaracaoId",
                table: "Foto",
                column: "DeclaracaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Declaracao_Foto",
                table: "Foto",
                column: "DeclaracaoId",
                principalTable: "Declaracao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declaracao_Foto",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_DeclaracaoId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "DeclaracaoId",
                table: "Foto");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Declaracao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
