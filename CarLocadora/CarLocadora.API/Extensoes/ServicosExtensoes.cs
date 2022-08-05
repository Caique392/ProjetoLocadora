using CarLocadora.Infra.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.API.Extensoes
{
    public static class ServicosExtensoes
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {
            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234;Initial Catalog=DBCarLocadora;";

            services.AddDbContext<Context>(item => item.UseSqlServer(connectionString));
        }
    }
}
