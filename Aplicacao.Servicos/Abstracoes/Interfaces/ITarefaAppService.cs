using Aplicacao.Servicos.DTO;
using Aplicacao.Servicos.DTO.Tarefas;

namespace Aplicacao.Servicos.Abstracoes.Interfaces
{
    public interface ITarefaAppService
    {
        Task<TarefaResponse> AdicionarAsync(AdicionarTarefaRequest request);
        Task<TarefaResponse> EditarAsync(Guid id, EditarTarefaRequest request);
        Task<bool> ConcluirAsync(Guid id);
        Task<bool> ReabrirAsync(Guid id);
        Task<bool> ExcluirAsync(Guid id);
        Task<TarefaResponse> RecuperarAsync(Guid id);
        Task<IEnumerable<TarefaResponse>> ListarAsync();
    }
}
