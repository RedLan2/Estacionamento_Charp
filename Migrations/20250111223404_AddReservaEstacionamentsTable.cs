using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    public partial class AddReservaEstacionamentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "placa",
                table: "Veiculo",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

       

            migrationBuilder.CreateTable(
                name: "ReservaEstacionaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstacionamentoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    placa = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaEstacionaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaEstacionaments_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaEstacionaments_Estacionamentos_EstacionamentoId",
                        column: x => x.EstacionamentoId,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaEstacionaments_Veiculo_placa",
                        column: x => x.placa,
                        principalTable: "Veiculo",
                        principalColumn: "placa",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaEstacionaments_ClienteId",
                table: "ReservaEstacionaments",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaEstacionaments_EstacionamentoId",
                table: "ReservaEstacionaments",
                column: "EstacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaEstacionaments_placa",
                table: "ReservaEstacionaments",
                column: "placa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaEstacionaments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Veiculo_placa",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "valorVaga",
                table: "Estacionamentos");

            migrationBuilder.AlterColumn<string>(
                name: "placa",
                table: "Veiculo",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
