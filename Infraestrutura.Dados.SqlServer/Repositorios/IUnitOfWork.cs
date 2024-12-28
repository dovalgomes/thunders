using Dominio.Negocio.Servicos.Interfaces;

namespace Dominio.Negocio.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        void Rollback();
        void BeginTransaction();
    }
}
