using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento_aluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AluguelVagas_VagaEstacionamentoId",
                table: "AluguelVagas",
                column: "VagaEstacionamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AluguelVagas_VagaEstacionamentos_VagaEstacionamentoId",
                table: "AluguelVagas",
                column: "VagaEstacionamentoId",
                principalTable: "VagaEstacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AluguelVagas_VagaEstacionamentos_VagaEstacionamentoId",
                table: "AluguelVagas");

            migrationBuilder.DropIndex(
                name: "IX_AluguelVagas_VagaEstacionamentoId",
                table: "AluguelVagas");
        }
    }
}
