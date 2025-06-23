using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public byte[] Contrasena { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public string? Email { get; set; }

    public int? RolId { get; set; }

    public virtual Role? Rol { get; set; }
}
