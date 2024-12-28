namespace Aplicacao.Servicos.DTO
{
    public class Resultado
    {
        public bool Sucesso { get; }
        public string Mensagem { get; }
        public IEnumerable<string> Erros { get; }

        protected Resultado(bool sucesso, string mensagem, IEnumerable<string>? erros = null)
        {
            Sucesso = sucesso;
            Mensagem = mensagem; 
            Erros = erros ?? Enumerable.Empty<string>();
        }

        public static Resultado Ok(string mensagem = "Operação realizada com sucesso")
        {
            return new Resultado(true, mensagem);
        }

        public static Resultado Falha(IEnumerable<string>? erros, string mensagem = "Erro na operação")
        {
            return new Resultado(false, mensagem, erros);
        }

        public static Resultado Falha(string erro, string mensagem = "Erro na operação")
        {
            return new Resultado(false, mensagem, new[] { erro });
        }
    }

    public class Resultado<T> : Resultado
    {
        public T Dados { get; }

        private Resultado(T dados, bool sucesso, string mensagem, IEnumerable<string>? erros = null)
            : base(sucesso, mensagem, erros)
        {
            Dados = dados;
        }

        public static Resultado<T> Ok(T dados, string mensagem = "Operação realizada com sucesso")
        {
            return new Resultado<T>(dados, true, mensagem);
        }

        public new static Resultado<T?> Falha(IEnumerable<string>? erros, string mensagem = "Erro na operação")
        {
            return new Resultado<T?>(default, false, mensagem, erros);
        }

        public new static Resultado<T?> Falha(string erro, string mensagem = "Erro na operação")
        {
            return new Resultado<T?>(default, false, mensagem, new[] { erro });
        }
    }



}
