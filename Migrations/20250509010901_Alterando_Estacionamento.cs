using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class Alterando_Estacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorDiaria",
                table: "Estacionamentos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

         /*   migrationBuilder.AddColumn<int>(
                name: "VagaEstacionamentoId1",
                table: "AluguelVagas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AluguelVagas_VagaEstacionamentoId1",
                table: "AluguelVagas",
                column: "VagaEstacionamentoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AluguelVagas_VagaEstacionamentos_VagaEstacionamentoId1",
                table: "AluguelVagas",
                column: "VagaEstacionamentoId1",
                principalTable: "VagaEstacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AluguelVagas_VagaEstacionamentos_VagaEstacionamentoId1",
                table: "AluguelVagas");

            migrationBuilder.DropIndex(
                name: "IX_AluguelVagas_VagaEstacionamentoId1",
                table: "AluguelVagas");

            migrationBuilder.DropColumn(
                name: "ValorDiaria",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "VagaEstacionamentoId1",
                table: "AluguelVagas");
        }
    }
}
