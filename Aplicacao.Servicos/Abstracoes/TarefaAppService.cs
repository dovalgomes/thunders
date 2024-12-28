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
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaAppService(ITarefaServico tarefaServico, IMapper mapper, IUnitOfWork unitOfWork, ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaServico = tarefaServico;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tarefaRepositorio = tarefaRepositorio;
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

        public async Task<bool> ConcluirAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var concluiu = await _tarefaServico.ConcluirAsync(id);
            await _unitOfWork.CommitAsync();
            return concluiu;
        }

        public async Task<bool> ReabrirAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var reabriu = await _tarefaServico.ReabrirAsync(id);
            await _unitOfWork.CommitAsync();
            return reabriu;
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var excluiu = await _tarefaServico.ExcluirAsync(id);
            await _unitOfWork.CommitAsync();
            return excluiu;
        }

        public async Task<TarefaResponse> RecuperarAsync(Guid id)
        {
            return _mapper.Map<TarefaResponse>(await _tarefaRepositorio.RecuperarAsync(id));
        }

        public async Task<IEnumerable<TarefaResponse>> ListarAsync()
        {
            return _mapper.Map<IEnumerable<TarefaResponse>>(await _tarefaRepositorio.ListarAsync());
        }
    }
}
