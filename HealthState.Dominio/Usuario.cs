using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? RolId { get; set; }

    public virtual Role? Rol { get; set; }
}
