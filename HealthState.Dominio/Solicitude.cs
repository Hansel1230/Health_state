using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Solicitude
{
    public int SolicitudId { get; set; }

    public string? Descripcion { get; set; }

    public int? EstadoId { get; set; }

    public int? TipoId { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? MontoAprobado { get; set; }

    public int? PolizaId { get; set; }

    public int? PacienteId { get; set; }

    public int? AseguradoraId { get; set; }

    public string? Observaciones { get; set; }

    public virtual Aseguradora? Aseguradora { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Paciente? Paciente { get; set; }

    public virtual TipoSolicitude? Tipo { get; set; }
}
