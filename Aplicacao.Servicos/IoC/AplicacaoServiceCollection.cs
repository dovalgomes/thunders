using Aplicacao.Servicos.Abstracoes;
using Aplicacao.Servicos.Abstracoes.Interfaces;
using Aplicacao.Servicos.Profiles;
using Dominio.Negocio.IoC;
using Infraestrutura.CrossCutting.IoC;
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
            services.InjecaoCrossCutting();
            services.InjecaoDominio();

            services.AddScoped<ITarefaAppService, TarefaAppService>();

            services.AddAutoMapper(a =>
            {
                a.AddProfile(typeof(TarefaProfile));
            });

            return services;
        }
    }
}
