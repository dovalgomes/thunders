using Dominio.Negocio.Repositorios;
using Infraestrutura.Dados.SqlServer.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados.SqlServer.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContexto _context;

        private ITarefaRepositorio _tarefaRepositorio;
        public ITarefaRepositorio Tarefas => _tarefaRepositorio ??= new TarefaRepositorio(_context);

        public UnitOfWork(SqlServerContexto contexto)
        {
            _context = contexto;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.State = entry.State switch
                {
                    EntityState.Modified => EntityState.Unchanged,
                    EntityState.Added => EntityState.Detached,
                    EntityState.Deleted => EntityState.Unchanged,
                    _ => entry.State
                };
            }
        }
    }
}
