using System;
using System.Collections.Generic;

namespace HealthState.Infraestructura.Data;

public partial class TipoSolicitude
{
    public int TipoId { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
}
