using Dominio.Negocio.Entidades.Abstracao;

namespace Dominio.Negocio.Entidades
{
    public class Tarefa : Entidade
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public bool Concluida { get; private set; }

        // Construtor vazio para Entity Framework
        protected Tarefa() : base() { }

        public Tarefa(string titulo, string descricao) : base()
        {
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
        }

        public void Editar(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public void MarcarComoConcluida()
        {
            Concluida = true;
            DataConclusao = DateTime.Now;
        }

        public void Reabrir()
        {
            Concluida = false;
            DataConclusao = null;
        }
    }

    public static class TarefaConstants
    {
        public const string ComentarioId = "Chave primária (Identificador) de tarefa";
        public const string ObrigatorioTitulo = "Informe o titulo";
        public const int TamanhoMaximoTitulo = 100;

        public const string ComentarioTitulo = "Titulo da tarefa";
        public static string TamanhoMaximoTituloMensagem = $"A quantidade máxima de caracteres para o titulo é de {TamanhoMaximoTitulo}";

        public const int TamanhoMaximoDescricao = 250;
        public const string ObrigatorioDescricao = "Informe a descrição";
        public static string TamanhoMaximoDescricaoMensagem = $"A quantidade máxima de caracteres para a descrição é de {TamanhoMaximoDescricao}";


        public const string ComentarioDescricao = "Descrição da Tarefa";
        public const string ComentarioDataCriacao = "Data de criação da tarefa";
        public const string ComentarioDataConclusao = "Data de conclusão da tarefa";
        public const string ComentarioConcluida = "Sinaliza se a tarefa está concluida ou não";

    }
}