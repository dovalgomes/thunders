﻿using Dominio.Negocio.Repositorios;
using Infraestrutura.Dados.SqlServer.Contexto;
using Infraestrutura.Dados.SqlServer.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura.Dados.SqlServer.IoC
{
    public static class InfraestruturaServiceCollection
    {
        public static IServiceCollection InjecaoInfraestrutura(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SqlServer");
            services.AddDbContext<SqlServerContexto>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}