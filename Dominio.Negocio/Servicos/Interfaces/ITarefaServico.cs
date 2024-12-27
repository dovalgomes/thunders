using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Negocio.Entidades;

namespace Dominio.Negocio.Servicos.Interfaces
{
    public interface ITarefaServico
    {
        Task<Tarefa> AdicionarAsync(string titulo, string descricao);
        Task<Tarefa> EditarAsync(Guid id, string titulo, string descricao);

        Task<bool> ConcluirAsync(Guid id);
        Task<bool> ReabrirAsync(Guid id);
        Task<bool> ExcluirAsync(Guid id);
    }
}
