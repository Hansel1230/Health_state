using HealthState.Dominio.Enum;
using System;
using System.Collections.Generic;

namespace HealthState.Dominio;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public SexoEnum Sexo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int? PolizaId { get; set; }

    public int? AseguradoraId { get; set; }

    public string? Cedula { get; set; }

    public Aseguradora? Aseguradora { get; set; }

    public ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
}
