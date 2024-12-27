using Dominio.Negocio.Entidades;
using Infraestrutura.Dados.SqlServer.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados.SqlServer.Contexto
{
    public class SqlServerContexto : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public SqlServerContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}
