using Dominio.Negocio.Entidades;
using Dominio.Negocio.Extensoes;
using Dominio.Negocio.Repositorios;
using Dominio.Negocio.Servicos.Interfaces;
using Dominio.Negocio.Validacoes.Tarefas;

namespace Dominio.Negocio.Servicos
{
    public class TarefaServico : ITarefaServico
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly INotificacaoHandler _notificacaoHandler;

        public TarefaServico(ITarefaRepositorio tarefaRepositorio, INotificacaoHandler notificacaoHandler)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _notificacaoHandler = notificacaoHandler;
        }

        public async Task<Tarefa> AdicionarAsync(string titulo, string descricao)
        {
            var tarefa = new Tarefa(titulo, descricao);

            var validacao = await new AdicionarTarefaValidacao().ValidateAsync(tarefa);

            if (!validacao.EstaValido(_notificacaoHandler))
                return null;

            var existe = await _tarefaRepositorio.ExisteAsync(t => t.Titulo.ToLower() == titulo.ToLower());

            if (existe)
            {
                _notificacaoHandler.Notificar("regra-negocio", "Existe outra tarefa com este titulo");
                return null;
            }

            await _tarefaRepositorio.AdicionarAsync(tarefa);
            return tarefa;
        }

        public async Task<Tarefa> EditarAsync(Guid id, string titulo, string descricao)
        {
            var tarefa = await _tarefaRepositorio.RecuperarAsync(id);

            if (tarefa == null)
            {
                _notificacaoHandler.Notificar("regra-negocio", "Tarefa não encontrada");
                return null;
            }

            var validacao = await new EditarTarefaValidacao().ValidateAsync(tarefa);

            if (!validacao.EstaValido(_notificacaoHandler))
                return null;

            var existe = await _tarefaRepositorio.ExisteAsync(t => t.Titulo.ToLower() == titulo.ToLower() && t.Id != id);

            if (existe)
            {
                _notificacaoHandler.Notificar("regra-negocio", "Existe outra tarefa com este titulo");
                return null;
            }

            tarefa.Editar(titulo, descricao);
            await _tarefaRepositorio.AtualizarAsync(tarefa);

            return tarefa;

        }

        public Task<bool> ConcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReabrirAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
