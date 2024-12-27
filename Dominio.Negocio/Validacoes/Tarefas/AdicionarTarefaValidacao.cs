namespace Dominio.Negocio.Validacoes.Tarefas
{
    public class AdicionarTarefaValidacao: TarefaValidacao
    {
        public AdicionarTarefaValidacao()
        {
            ValidarTitulo();
            ValidarDescricao();
        }
    }
}
