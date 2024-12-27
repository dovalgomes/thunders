using Dominio.Negocio.Modelos;
using Dominio.Negocio.Servicos.Interfaces;

namespace Dominio.Negocio.Servicos
{
    public class NotificacaoHandler : INotificacaoHandler
    {
        private readonly List<Notificacao> _notificacoes = new();
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes.AsReadOnly();

        public void Notificar(string propriedade, string mensagem)
        {
            Notificar(new(propriedade, mensagem));
        }

        public void Notificar(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public IEnumerable<Notificacao> Obter()
        {
            return Notificacoes;
        }

        public bool PossuiNotificacoes() => Notificacoes.Any();
    }
}
