namespace Dominio.Negocio.Validacoes.Tarefas
{
    public class EditarTarefaValidacao: TarefaValidacao
    {
        public EditarTarefaValidacao()
        {
            ValidarTitulo();
            ValidarDescricao();
        }
    }
}
