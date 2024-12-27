using Aplicacao.Servicos.Abstracoes.Interfaces;
using Aplicacao.Servicos.DTO.Tarefas;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaAppService _tarefaAppService;

        public TarefasController(ITarefaAppService tarefaAppService)
        {
            _tarefaAppService = tarefaAppService;
        }

        /// <summary>
        /// Adicionar uma nova tarefa
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AdicionarAsync([FromBody] AdicionarTarefaRequest request)
        {
            var response = await _tarefaAppService.AdicionarAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar uma tarefa
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(Guid id, [FromBody] EditarTarefaRequest request)
        {
            var response = await _tarefaAppService.EditarAsync(id, request);
            return Ok(response);
        }

        ///// <summary>
        ///// Concluir uma tarefa
        ///// </summary>
        ///// <param name="id">Identificador da tarefa</param>
        ///// <returns></returns>
        //[HttpPatch("{id}/concluir")]
        //public async Task<IActionResult> ConcluirAsync(Guid id)
        //{
        //    return Ok();
        //}

        ///// <summary>
        ///// Reabrir uma tarefa
        ///// </summary>
        ///// <param name="id">Identificador da tarefa</param>
        ///// <returns></returns>
        //[HttpPatch("{id}/reabrir")]
        //public async Task<IActionResult> ReabrirAsync(Guid id)
        //{
        //    return Ok();
        //}

        ///// <summary>
        ///// Recuperar uma tarefa
        ///// </summary>
        ///// <param name="id">Identificador da tarefa</param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        //public async Task<IActionResult> RecuperarAsync(Guid id)
        //{
        //    return Ok();
        //}

        ///// <summary>
        ///// Listar todas as tarefas
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> ListarAsync()
        //{
        //    return Ok();
        //}

        ///// <summary>
        ///// Excluir uma tarefa
        ///// </summary>
        ///// <param name="id">Identificador da tarefa</param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> ExcluirAsync(Guid id)
        //{
        //    return Ok();
        //}
    }
}
