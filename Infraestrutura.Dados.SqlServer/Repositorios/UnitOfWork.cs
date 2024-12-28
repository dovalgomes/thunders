using Dominio.Negocio.Repositorios;
using Dominio.Negocio.Servicos.Interfaces;
using Infraestrutura.Dados.SqlServer.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados.SqlServer.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContexto _context;
        private readonly INotificacaoHandler _notificacaoHandler;

        public UnitOfWork(SqlServerContexto contexto, INotificacaoHandler notificacaoHandler)
        {
            _context = contexto;
            _notificacaoHandler = notificacaoHandler;
        }

        public async Task<bool> CommitAsync()
        {
            if (_notificacaoHandler.PossuiNotificacoes())
                return false;

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

        public void BeginTransaction()
        {

        }
    }
}
