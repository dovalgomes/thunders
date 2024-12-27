namespace Dominio.Negocio.Entidades.Abstracao
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
    }

}
