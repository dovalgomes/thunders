using Dominio.Negocio.Entidades;
using Dominio.Negocio.Repositorios;
using Infraestrutura.Dados.SqlServer.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Dados.SqlServer.Repositorios
{
    public class TarefaRepositorio : Repositorio<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(SqlServerContexto contexto) : base(contexto)
        {
        }
    }
}
