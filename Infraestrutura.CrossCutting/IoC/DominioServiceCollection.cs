using Dominio.Negocio.Servicos;
using Dominio.Negocio.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura.CrossCutting.IoC
{
    public static class DominioServiceCollection
    {
        public static IServiceCollection InjecaoCrossCutting(this IServiceCollection services)
        {
            services.AddScoped<INotificacaoHandler, NotificacaoHandler>();

            return services;
        }
    }
}
