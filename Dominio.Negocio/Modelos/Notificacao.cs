namespace Dominio.Negocio.Modelos
{
    public class Notificacao
    {
        public string Propriedade { get; }
        public string Mensagem { get; }

        public Notificacao(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }
    }
}
