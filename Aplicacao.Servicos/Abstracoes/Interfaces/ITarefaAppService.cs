using Aplicacao.Servicos.DTO;
using Aplicacao.Servicos.DTO.Tarefas;

namespace Aplicacao.Servicos.Abstracoes.Interfaces
{
    public interface ITarefaAppService
    {
        Task<TarefaResponse> AdicionarAsync(AdicionarTarefaRequest request);
        Task<TarefaResponse> EditarAsync(Guid id, EditarTarefaRequest request);
    }
}
