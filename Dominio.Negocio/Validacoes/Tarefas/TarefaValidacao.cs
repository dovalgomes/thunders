using Dominio.Negocio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio.Validacoes.Tarefas
{
    public abstract class TarefaValidacao : AbstractValidator<Tarefa>
    {
        public void ValidarTitulo()
        {
            RuleFor(r => r.Titulo).NotEmpty()
                .WithMessage(TarefaConstants.ObrigatorioTitulo)
                .MaximumLength(TarefaConstants.TamanhoMaximoTitulo)
                .WithMessage(TarefaConstants.TamanhoMaximoTituloMensagem);
        }

        public void ValidarDescricao()
        {
            RuleFor(r => r.Descricao).NotEmpty()
                .WithMessage(TarefaConstants.ObrigatorioDescricao)
                .MaximumLength(TarefaConstants.TamanhoMaximoDescricao)
                .WithMessage(TarefaConstants.TamanhoMaximoDescricaoMensagem);
        }
    }
}
