namespace HealthState.Aplicacion.Usuarios.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public string? RolNombre { get; set; }

    }
}
