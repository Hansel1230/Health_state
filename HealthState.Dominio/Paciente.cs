using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int? PolizaId { get; set; }

    public int? AseguradoraId { get; set; }

    public virtual Aseguradora? Aseguradora { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
}
