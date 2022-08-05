using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.Infra.Migrations
{
    public partial class CriacaoBanco2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "formasPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formasPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "veiculos",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Chassi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Combustivel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opcionais = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculos", x => x.Placa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "formasPagamentos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "veiculos");
        }
    }
}
