namespace Dominio.Negocio.Entidades.Abstracao
{
    public interface IAuditavel
    {
        Guid Id { get; }
        TipoAcaoEnum TipoAcao { get; set; }
        DateTime Data { get; set; }

        void Auditar();

    }
}
