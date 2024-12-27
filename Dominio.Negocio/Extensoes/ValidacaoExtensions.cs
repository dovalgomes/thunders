using Dominio.Negocio.Servicos.Interfaces;

namespace Dominio.Negocio.Extensoes
{
    public static class ValidacaoExtensions
    {
        public static bool EstaValido(this FluentValidation.Results.ValidationResult validacao, INotificacaoHandler notificacao)
        {
            if (validacao.IsValid)
                return true;

            foreach (var error in validacao.Errors)
            {
                notificacao.Notificar(error.PropertyName, error.ErrorMessage);
                break;
            }

            return false;
        }
    }
}
