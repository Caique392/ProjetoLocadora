using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.Infra.Migrations
{
    public partial class CorrecaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "formasPagamentos",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_veiculos_CategoriaId",
                table: "veiculos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculos_categorias_CategoriaId",
                table: "veiculos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculos_categorias_CategoriaId",
                table: "veiculos");

            migrationBuilder.DropIndex(
                name: "IX_veiculos_CategoriaId",
                table: "veiculos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "veiculos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "formasPagamentos",
                newName: "ID");
        }
    }
}
