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
        protected Tarefa() { }

        public Tarefa(string titulo, string descricao) : base()
        {
            DefinirTitulo(titulo);
            DefinirDescricao(descricao);
            DataCriacao = DateTime.Now;
        }

        public void DefinirTitulo(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
                throw new ArgumentException("Informe o titulo da tarefa");

            Titulo = titulo;
        }

        public void DefinirDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("Informe a descrição da tarefa");

            Descricao = descricao;
        }

        public void MarcarComoConcluida()
        {
            if (Concluida)
                throw new ArgumentException("A tarefa já está concluída");

            Concluida = true;
            DataConclusao = DateTime.Now;
        }

        public void Reabrir()
        {
            if (!Concluida)
                throw new ArgumentException("A tarefa já está aberta");

            Concluida = false;
            DataConclusao = null;
        }
    }
}