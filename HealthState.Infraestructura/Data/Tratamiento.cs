using System;
using System.Collections.Generic;

namespace HealthState.Infraestructura.Data;

public partial class Tratamiento
{
    public int TratamientoId { get; set; }

    public int? CitaId { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Costo { get; set; }

    public bool? Cubierto { get; set; }

    public virtual Cita? Cita { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
