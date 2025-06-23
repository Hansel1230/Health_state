using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int? PacienteId { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public decimal? Monto { get; set; }

    public bool? Pagado { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Paciente? Paciente { get; set; }
}
