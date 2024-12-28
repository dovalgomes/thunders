namespace Dominio.Negocio.Entidades.Abstracoes
{
    public abstract class Entidade
    {
        public Guid Id { get; protected set; }
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
    }

}
