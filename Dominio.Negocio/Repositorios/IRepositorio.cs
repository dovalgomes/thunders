using System.Linq.Expressions;
using Dominio.Negocio.Entidades.Abstracoes;

namespace Dominio.Negocio.Repositorios;

public interface IRepositorio<T> where T : Entidade
{
    Task<T> AdicionarAsync(T entidade);
    Task<T> AtualizarAsync(T entidade);
    Task<T> RemoverAsync(T entidade);
    Task<T?> RecuperarAsync(Guid id);
    Task<T?> RecuperarAsync(Expression<Func<T, bool>> expressao);
    Task<IEnumerable<T>> ListarAsync();
    Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> expressao);
    Task<bool> ExisteAsync(Expression<Func<T, bool>> expressao);

}