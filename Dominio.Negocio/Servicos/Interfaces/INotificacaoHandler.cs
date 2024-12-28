using Dominio.Negocio.Modelos;

namespace Dominio.Negocio.Servicos.Interfaces
{
    public interface INotificacaoHandler
    {
        bool PossuiNotificacoes();
        void Notificar(string propriedade, string mensagem);
        void Notificar(Notificacao notificacaoHandler);
        IEnumerable<Notificacao> Obter();
    }
}
