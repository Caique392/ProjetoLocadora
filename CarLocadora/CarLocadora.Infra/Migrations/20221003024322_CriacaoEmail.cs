using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.Infra.Migrations
{
    public partial class CriacaoEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailEnviado",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    FormaPagamentoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaPagamentoId1 = table.Column<int>(type: "int", nullable: true),
                    DataHoraReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraRetiradaPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeiculoPlaca = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacao_Clientes_ClienteCPF",
                        column: x => x.ClienteCPF,
                        principalTable: "Clientes",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacao_formasPagamentos_FormaPagamentoId1",
                        column: x => x.FormaPagamentoId1,
                        principalTable: "formasPagamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_ClienteCPF",
                table: "Locacao",
                column: "ClienteCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_FormaPagamentoId1",
                table: "Locacao",
                column: "FormaPagamentoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EmailEnviado",
                table: "Clientes");
        }
    }
}
