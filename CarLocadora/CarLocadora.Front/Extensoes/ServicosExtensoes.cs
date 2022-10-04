using CarLocadora.Comum;
using CarLocadora.Comum.Modelo;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Front.Extensoes
{
    public static class ServicosExtensoes
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IApiToken, ApiToken>();
            services.AddSingleton<LoginRespostaModel>();
        }

        public static void ConfigurarAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DadosBase>(configuration.GetSection("DadosBase"));
        }
    }
}
