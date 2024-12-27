using Dominio.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.SqlServer.Mapeamentos
{
    public class TarefaMapeamento : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasComment(TarefaConstants.COMENTARIO_ID);

            builder.Property(p => p.Titulo)
                   .IsRequired()
                   .HasMaxLength(TarefaConstants.TAMANHO_MAXIMO_TITULO)
                   .HasComment(TarefaConstants.COMENTARIO_TITULO);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(TarefaConstants.TAMANHO_MAXIMO_DESCRICAO)
                   .HasComment(TarefaConstants.COMENTARIO_DESCRICAO);

            builder.Property(p => p.DataCriacao)
                   .IsRequired()
                   .HasComment(TarefaConstants.COMENTARIO_DATA_CRIACAO);

            builder.Property(p => p.DataConclusao)
                   .IsRequired(false)
                   .HasComment(TarefaConstants.COMENTARIO_DATA_CONCLUSAO);

            builder.Property(p => p.Concluida)
                .IsRequired()
                .HasComment(TarefaConstants.COMENTARIO_CONCLUIDA);
        }
    }
}
