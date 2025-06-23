using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Cita
{
    public int CitaId { get; set; }

    public int? PacienteId { get; set; }

    public int? MedicoId { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? MotivoConsulta { get; set; }

    public int? EstadoId { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Medico? Medico { get; set; }

    public virtual Paciente? Paciente { get; set; }

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
