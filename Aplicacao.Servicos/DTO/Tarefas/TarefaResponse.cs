namespace Aplicacao.Servicos.DTO.Tarefas
{
    public record TarefaResponse (Guid Id, string Titulo, string Descricao, DateTime DataCriacao, DateTime? DataConclusao, bool Concluida);
}
