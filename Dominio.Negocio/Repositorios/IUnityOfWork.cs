namespace Dominio.Negocio.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        ITarefaRepositorio Tarefas { get; }
        Task<bool> CommitAsync();
        void Rollback();
    }
}
