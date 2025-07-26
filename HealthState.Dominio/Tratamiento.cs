using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Tratamiento
{
    public int TratamientoId { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
