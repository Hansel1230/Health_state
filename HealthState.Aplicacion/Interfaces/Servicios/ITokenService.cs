namespace HealthState.Aplicacion.Interfaces.Servicios
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(CancellationToken cancellationToken = default);
    }
}
