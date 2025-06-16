using System;
using System.Collections.Generic;

namespace HealthState.Infraestructura.Data;

public partial class Medico
{
    public int MedicoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string? Especialidad { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
