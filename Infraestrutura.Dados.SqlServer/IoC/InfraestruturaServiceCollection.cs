using Dominio.Negocio.Repositorios;
using Infraestrutura.Dados.SqlServer.Contexto;
using Infraestrutura.Dados.SqlServer.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infraestrutura.Dados.SqlServer.IoC
{
    public static class InfraestruturaServiceCollection
    {
        public static IServiceCollection InjecaoInfraestrutura(this IServiceCollection services, IConfiguration config)
        {
            var logger = services.BuildServiceProvider().GetRequiredService<ILogger<SqlServerContexto>>();

            logger.LogInformation("Configurando banco de dados");


            var connectionString = config.GetConnectionString("SqlServer");
            services.AddDbContext<SqlServerContexto>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            try
            {
                logger.LogInformation("Iniciando migração automática");
                var scopeDatabase = services.BuildServiceProvider().GetRequiredService<SqlServerContexto>();
                var db = scopeDatabase.Database;
                db.Migrate();
                logger.LogInformation("Migração executada com sucesso");
            }
            catch (Exception ex)
            {
                logger.LogError($"Falha ao executar migração:{ex.Message}");
            }

            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

            services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
