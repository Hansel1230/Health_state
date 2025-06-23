using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
}
