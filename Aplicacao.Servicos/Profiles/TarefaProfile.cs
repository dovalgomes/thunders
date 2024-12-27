using Aplicacao.Servicos.DTO.Tarefas;
using AutoMapper;
using Dominio.Negocio.Entidades;

namespace Aplicacao.Servicos.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaResponse>();
        }
    }
}
