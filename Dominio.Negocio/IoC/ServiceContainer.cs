using Dominio.Negocio.Servicos;
using Dominio.Negocio.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dominio.Negocio.IoC
{
    public static class ServiceContainer
    {
        public static IServiceCollection InjecaoDominio(this IServiceCollection services)
        {
            services.AddScoped<ITarefaServico, TarefaServico>();

            return services;
        }
    }
}
