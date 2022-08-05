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
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Veiculos> veiculos { get; set; }
        public DbSet<FormasPagamento> formasPagamentos { get; set; }



    }
}
