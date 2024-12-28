using Dominio.Negocio.Entidades;

namespace Dominio.Negocio.Testes.Entidades
{
    public class TarefaTests
    {
        [Fact]
        public void Construtor_DeveInicializarCamposCorretamente()
        {
            // Arrange
            var titulo = "Título da tarefa";
            var descricao = "Descrição da tarefa";

            // Act
            var tarefa = new Tarefa(titulo, descricao);

            // Assert
            Assert.Equal(titulo, tarefa.Titulo);
            Assert.Equal(descricao, tarefa.Descricao);
            Assert.False(tarefa.Concluida);
            Assert.Null(tarefa.DataConclusao);
            Assert.True((DateTime.Now - tarefa.DataCriacao).TotalSeconds < 1, "Data de criação deve ser inicializada como o momento atual.");
        }

        [Fact]
        public void Editar_DeveAtualizarTituloEDescricao()
        {
            // Arrange
            var tarefa = new Tarefa("Título antigo", "Descrição antiga");
            var novoTitulo = "Novo título";
            var novaDescricao = "Nova descrição";

            // Act
            tarefa.Editar(novoTitulo, novaDescricao);

            // Assert
            Assert.Equal(novoTitulo, tarefa.Titulo);
            Assert.Equal(novaDescricao, tarefa.Descricao);
        }

        [Fact]
        public void MarcarComoConcluida_DeveAtualizarConcluidaEDataConclusao()
        {
            // Arrange
            var tarefa = new Tarefa("Título", "Descrição");

            // Act
            tarefa.MarcarComoConcluida();

            // Assert
            Assert.True(tarefa.Concluida);
            Assert.NotNull(tarefa.DataConclusao);
            Assert.True((DateTime.Now - tarefa.DataConclusao.Value).TotalSeconds < 1, "Data de conclusão deve ser inicializada como o momento atual.");
        }

        [Fact]
        public void Reabrir_DeveAtualizarConcluidaEDataConclusao()
        {
            // Arrange
            var tarefa = new Tarefa("Título", "Descrição");
            tarefa.MarcarComoConcluida();

            // Act
            tarefa.Reabrir();

            // Assert
            Assert.False(tarefa.Concluida);
            Assert.Null(tarefa.DataConclusao);
        }

        [Fact]
        public void ConstrutorProtegido_DeveSerUsadoApenasPorEFCore()
        {
            // Arrange & Act
            var tarefa = (Tarefa)Activator.CreateInstance(typeof(Tarefa), true);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Null(tarefa.Titulo);
            Assert.Null(tarefa.Descricao);
            Assert.False(tarefa.Concluida);
            Assert.Null(tarefa.DataConclusao);
            Assert.Equal(default(DateTime), tarefa.DataCriacao);
        }
    }

}
