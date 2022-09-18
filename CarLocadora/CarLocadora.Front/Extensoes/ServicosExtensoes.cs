using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Modelo.Models;
using CarLocadora.Servico;

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
