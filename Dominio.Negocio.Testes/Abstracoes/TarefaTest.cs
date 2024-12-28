using Dominio.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio.Testes.Abstracoes
{
    public class TarefaTest : Tarefa
    {
        public TarefaTest(Guid id, string titulo, string descricao) : base(titulo, descricao)
        {
            Id = id;
        }
    }
}
