using Dominio.Negocio.Entidades;
using Infraestrutura.Dados.SqlServer.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados.SqlServer.Contexto
{
    public class SqlServerContexto(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}
