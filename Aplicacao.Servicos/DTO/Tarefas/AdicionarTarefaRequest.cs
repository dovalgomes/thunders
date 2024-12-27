using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos.DTO.Tarefas
{
    public record AdicionarTarefaRequest (string Titulo, string Descricao);
}
