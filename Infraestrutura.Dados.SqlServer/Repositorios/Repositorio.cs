using Dominio.Negocio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Dominio.Negocio.Entidades.Abstracoes;

namespace Infraestrutura.Dados.SqlServer.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repositorio(DbContext contexto)
        {
            _context = contexto;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AdicionarAsync(T entidade)
        {
            var entry = await _dbSet.AddAsync(entidade);
            return entry.Entity;
        }

        public async Task<T> AtualizarAsync(T entidade)
        {
            var entry = _dbSet.Update(entidade);
            return await Task.FromResult(entry.Entity);
        }

        public async Task<IEnumerable<T>> ListarAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> expressao)
        {
            return await _dbSet.Where(expressao).ToListAsync();
        }

        public async Task<bool> ExisteAsync(Expression<Func<T, bool>> expressao)
        {
            return await _dbSet.AnyAsync(expressao);
        }

        public async Task<T?> RecuperarAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T?> RecuperarAsync(Expression<Func<T, bool>> expressao)
        {
            return await _dbSet.FirstOrDefaultAsync(expressao);
        }

        public async Task<T> RemoverAsync(T entidade)
        {
            var entry = _dbSet.Remove(entidade);
            return await Task.FromResult(entry.Entity);
        }
    }
}
