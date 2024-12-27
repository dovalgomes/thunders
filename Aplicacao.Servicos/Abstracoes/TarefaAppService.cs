using Aplicacao.Servicos.Abstracoes.Interfaces;
using Aplicacao.Servicos.DTO.Tarefas;
using AutoMapper;
using Dominio.Negocio.Repositorios;
using Dominio.Negocio.Servicos.Interfaces;

namespace Aplicacao.Servicos.Abstracoes
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly ITarefaServico _tarefaServico;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TarefaAppService(ITarefaServico tarefaServico, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tarefaServico = tarefaServico;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TarefaResponse> AdicionarAsync(AdicionarTarefaRequest request)
        {
            _unitOfWork.BeginTransaction();

            var tarefa = await _tarefaServico.AdicionarAsync(request.Titulo, request.Descricao);
            var response = _mapper.Map<TarefaResponse>(tarefa);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<TarefaResponse> EditarAsync(Guid id, EditarTarefaRequest request)
        {
            _unitOfWork.BeginTransaction();
            var tarefa = await _tarefaServico.EditarAsync(id, request.Titulo, request.Descricao);
            var response = _mapper.Map<TarefaResponse>(tarefa);
            await _unitOfWork.CommitAsync();
            return response;
        }
    }
}
