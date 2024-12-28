using Dominio.Negocio.Entidades;
using Dominio.Negocio.Repositorios;
using Dominio.Negocio.Servicos;
using Dominio.Negocio.Servicos.Interfaces;
using Dominio.Negocio.Testes.Abstracoes;
using Moq;
using System.Linq.Expressions;

namespace Dominio.Negocio.Testes.Servicos
{
    public class TarefaServicoTests
    {
        private readonly Mock<ITarefaRepositorio> _tarefaRepositorioMock;
        private readonly Mock<INotificacaoHandler> _notificacaoHandlerMock;
        private readonly ITarefaServico _tarefaServico;

        public TarefaServicoTests()
        {
            _tarefaRepositorioMock = new Mock<ITarefaRepositorio>();
            _notificacaoHandlerMock = new Mock<INotificacaoHandler>();
            _tarefaServico = new TarefaServico(_tarefaRepositorioMock.Object, _notificacaoHandlerMock.Object);
        }

        [Fact]
        public async Task AdicionarAsync_DeveAdicionarTarefa_QuandoValidacaoEhValida()
        {
            // Arrange
            var titulo = "Nova Tarefa";
            var descricao = "Descrição da nova tarefa";

            _tarefaRepositorioMock.Setup(repo => repo.ExisteAsync(It.IsAny<Expression<Func<Tarefa, bool>>>()))
                .ReturnsAsync(false);

            // Act
            var resultado = await _tarefaServico.AdicionarAsync(titulo, descricao);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(titulo, resultado.Titulo);
            Assert.Equal(descricao, resultado.Descricao);
            _tarefaRepositorioMock.Verify(repo => repo.AdicionarAsync(It.IsAny<Tarefa>()), Times.Once);
        }

        [Fact]
        public async Task AdicionarAsync_DeveNotificar_QuandoJaExisteTarefaComMesmoTitulo()
        {
            // Arrange
            var titulo = "Tarefa Existente";
            var descricao = "Descrição";

            _tarefaRepositorioMock.Setup(repo => repo.ExisteAsync(It.IsAny<Expression<Func<Tarefa, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await _tarefaServico.AdicionarAsync(titulo, descricao);

            // Assert
            Assert.Null(resultado);
            _notificacaoHandlerMock.Verify(n => n.Notificar("regra-negocio", "Existe outra tarefa não concluída com este titulo"), Times.Once);
        }

        [Fact]
        public async Task EditarAsync_DeveEditarTarefa_QuandoValidacaoEhValida()
        {
            // Arrange
            var id = Guid.NewGuid();
            var titulo = "Tarefa Atualizada";
            var descricao = "Descrição Atualizada";

            var tarefa = new TarefaTest(id, "Titulo Antigo", "Descricao Antiga");
            _tarefaRepositorioMock.Setup(repo => repo.RecuperarAsync(id)).ReturnsAsync(tarefa);
            _tarefaRepositorioMock.Setup(repo => repo.ExisteAsync(It.IsAny<Expression<Func<Tarefa, bool>>>()))
                .ReturnsAsync(false);

            // Act
            var resultado = await _tarefaServico.EditarAsync(id, titulo, descricao);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(titulo, resultado.Titulo);
            Assert.Equal(descricao, resultado.Descricao);
            _tarefaRepositorioMock.Verify(repo => repo.AtualizarAsync(tarefa), Times.Once);
        }

        [Fact]
        public async Task ConcluirAsync_DeveMarcarTarefaComoConcluida()
        {
            // Arrange
            var id = Guid.NewGuid();
            var tarefa = new TarefaTest(id, "Titulo", "Descricao");
            _tarefaRepositorioMock.Setup(repo => repo.RecuperarAsync(id)).ReturnsAsync(tarefa);

            // Act
            var resultado = await _tarefaServico.ConcluirAsync(id);

            // Assert
            Assert.True(resultado);
            Assert.True(tarefa.Concluida);
            _tarefaRepositorioMock.Verify(repo => repo.AtualizarAsync(tarefa), Times.Once);
        }

        [Fact]
        public async Task ConcluirAsync_DeveNotificar_QuandoTarefaJaConcluida()
        {
            // Arrange
            var id = Guid.NewGuid();
            var tarefa = new TarefaTest(id, "Titulo", "Descricao");
            tarefa.MarcarComoConcluida();
            _tarefaRepositorioMock.Setup(repo => repo.RecuperarAsync(id)).ReturnsAsync(tarefa);

            // Act
            var resultado = await _tarefaServico.ConcluirAsync(id);

            // Assert
            Assert.False(resultado);
            _notificacaoHandlerMock.Verify(n => n.Notificar("regra-negocio", "A Tarefa já foi concluída"), Times.Once);
        }

        [Fact]
        public async Task ExcluirAsync_DeveExcluirTarefa()
        {
            // Arrange
            var id = Guid.NewGuid();
            var tarefa = new TarefaTest(id, "Titulo", "Descricao");
            _tarefaRepositorioMock.Setup(repo => repo.RecuperarAsync(id)).ReturnsAsync(tarefa);

            // Act
            var resultado = await _tarefaServico.ExcluirAsync(id);

            // Assert
            Assert.True(resultado);
            _tarefaRepositorioMock.Verify(repo => repo.RemoverAsync(tarefa), Times.Once);
        }

        [Fact]
        public async Task ReabrirAsync_DeveReabrirTarefa()
        {
            // Arrange
            var id = Guid.NewGuid();
            var tarefa = new TarefaTest(id, "Titulo", "Descricao");
            tarefa.MarcarComoConcluida();
            _tarefaRepositorioMock.Setup(repo => repo.RecuperarAsync(id)).ReturnsAsync(tarefa);

            // Act
            var resultado = await _tarefaServico.ReabrirAsync(id);

            // Assert
            Assert.True(resultado);
            Assert.False(tarefa.Concluida);
            Assert.Null(tarefa.DataConclusao);
            _tarefaRepositorioMock.Verify(repo => repo.AtualizarAsync(tarefa), Times.Once);
        }
    }

}
