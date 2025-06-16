using System;
using System.Collections.Generic;

namespace HealthState.Infraestructura.Data;

public partial class DetalleFactura
{
    public int DetalleId { get; set; }

    public int? FacturaId { get; set; }

    public int? TratamientoId { get; set; }

    public decimal? Monto { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Tratamiento? Tratamiento { get; set; }
}
