using Aplicacao.Servicos.DTO;
using Dominio.Negocio.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Middlewares
{
    public class ResultFilter : IAsyncActionFilter
    {
        private readonly INotificacaoHandler _notificacaoHandler;

        public ResultFilter(INotificacaoHandler notificacaoHandler)
        {
            _notificacaoHandler = notificacaoHandler;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (_notificacaoHandler.PossuiNotificacoes())
            {
                var notificacoes = _notificacaoHandler.Obter();
                resultContext.Result = new BadRequestObjectResult(new
                {
                    sucesso = false,
                    mensagem = "Erro(s) na validação",
                    erros = notificacoes.Select(n => new { n.Propriedade, n.Mensagem })
                });
                return;
            }

            if (resultContext.Result is ObjectResult objectResult && objectResult.Value is not Resultado<object>)
            {
                resultContext.Result = new OkObjectResult(new
                {
                    sucesso = true,
                    mensagem = "Operação realizada com sucesso",
                    dados = objectResult.Value
                });
            }

        }
    }
}
