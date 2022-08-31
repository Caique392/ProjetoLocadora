using CarLocadora.Modelo;
using CarLocadora.Modelo.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Infra.Entity
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options ) : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<CategoriaModel> categorias { get; set; }
        public DbSet<UsuarioModel> usuarios { get; set; }
        public DbSet<VeiculoModel> veiculos { get; set; }
        public DbSet<FormaPagamentoModel> formasPagamentos { get; set; }
        public DbSet<ManutencaoVeiculoModel> ManutencaoVeiculo { get; set; }



    }
}
