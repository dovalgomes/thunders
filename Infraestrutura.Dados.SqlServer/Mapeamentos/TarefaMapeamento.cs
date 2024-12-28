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

            builder.Property(f => f.Id).HasComment(TarefaConstants.ComentarioId);

            builder.Property(p => p.Titulo)
                   .IsRequired()
                   .HasMaxLength(TarefaConstants.TamanhoMaximoTitulo)
                   .HasComment(TarefaConstants.ComentarioTitulo);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(TarefaConstants.TamanhoMaximoDescricao)
                   .HasComment(TarefaConstants.ComentarioDescricao);

            builder.Property(p => p.DataCriacao)
                   .IsRequired()
                   .HasComment(TarefaConstants.ComentarioDataCriacao);

            builder.Property(p => p.DataConclusao)
                   .IsRequired(false)
                   .HasComment(TarefaConstants.ComentarioDataConclusao);

            builder.Property(p => p.Concluida)
                .IsRequired()
                .HasComment(TarefaConstants.ComentarioConcluida);
        }
    }
}
