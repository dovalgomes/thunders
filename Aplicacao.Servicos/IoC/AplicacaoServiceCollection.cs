using Infraestrutura.Dados.SqlServer.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.Servicos.IoC
{
    public static class AplicacaoServiceCollection
    {
        public static IServiceCollection InjecaoAplicacao(this IServiceCollection services, IConfiguration config)
        {
            services.InjecaoInfraestrutura(config);

            return services;
        }
    }
}
