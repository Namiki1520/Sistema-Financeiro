using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_SistemaFinanceiro_IdSistema",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Categoria_IdCategoria",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_IdCategoria",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_IdSistema",
                table: "Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Despesa_IdCategoria",
                table: "Despesa",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_IdSistema",
                table: "Categoria",
                column: "IdSistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_SistemaFinanceiro_IdSistema",
                table: "Categoria",
                column: "IdSistema",
                principalTable: "SistemaFinanceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Categoria_IdCategoria",
                table: "Despesa",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
