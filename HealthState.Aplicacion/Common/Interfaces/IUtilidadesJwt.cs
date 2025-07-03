using HealthState.Aplicacion.Usuarios.Models;

namespace HealthState.Aplicacion.Common.Interfaces
{
    public interface IUtilidadesJwt
    {
        public string encriptarSha256(string texto);
        public string GenerarJwt(UsuarioModel modelo);

    }
}