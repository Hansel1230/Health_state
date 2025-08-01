using HealthState.Dominio;
using HealthState.Dominio.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace HealthState.Infraestructura.Data;

public partial class HealthStateContext : DbContext
{
    public HealthStateContext()
    {
    }

    public HealthStateContext(DbContextOptions<HealthStateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aseguradora> Aseguradoras { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    public virtual DbSet<TipoSolicitude> TipoSolicitudes { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aseguradora>(entity =>
        {
            entity.HasKey(e => e.AseguradoraId).HasName("PK__Asegurad__283AECB69AD075DD");

            entity.Property(e => e.AseguradoraId).HasColumnName("AseguradoraID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F26FA59FEB");

            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.MedicoId).HasColumnName("MedicoID");
            entity.Property(e => e.MotivoConsulta).HasMaxLength(200);
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

            entity.HasOne(d => d.Estado).WithMany(p => p.Cita)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Citas__EstadoID__3A81B327");

            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__Citas__MedicoID__3B75D760");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Citas__PacienteI__3C69FB99");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleF__6E19D6FA4C16E3D7");

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TratamientoId).HasColumnName("TratamientoID");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__DetalleFa__Factu__3D5E1FD2");

            entity.HasOne(d => d.Tratamiento).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.TratamientoId)
                .HasConstraintName("FK__DetalleFa__Trata__3E52440B");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estados__FEF86B604D136ED0");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805AADA794E");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Facturas__Pacien__3F466844");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.MedicoId).HasName("PK__Medicos__5953C276C434AF30");

            entity.Property(e => e.MedicoId).HasColumnName("MedicoID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Cedula)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__Paciente__9353C07F65E881CB");

            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");
            entity.Property(e => e.AseguradoraId).HasColumnName("AseguradoraID");
            entity.Property(e => e.Cedula)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.PolizaId).HasColumnName("PolizaID");
            entity.Property(e => e.Sexo)
            .HasConversion(new EnumToStringConverter<SexoEnum>());
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Aseguradora).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.AseguradoraId)
                .HasConstraintName("FK__Pacientes__Asegu__403A8C7D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D185DA36CC");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA7D3B6CC41");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.AseguradoraId).HasColumnName("AseguradoraID");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.MontoAprobado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Observaciones).HasMaxLength(200);
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");
            entity.Property(e => e.PolizaId).HasColumnName("PolizaID");
            entity.Property(e => e.TipoId).HasColumnName("TipoID");

            entity.HasOne(d => d.Aseguradora).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.AseguradoraId)
                .HasConstraintName("FK__Solicitud__Asegu__412EB0B6");

            entity.HasOne(d => d.Estado).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Solicitud__Estad__4222D4EF");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Solicitud__Pacie__4316F928");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__Solicitud__TipoI__440B1D61");
        });

        modelBuilder.Entity<TipoSolicitude>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__TipoSoli__97099E970D22210D");

            entity.Property(e => e.TipoId).HasColumnName("TipoID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.TratamientoId).HasName("PK__Tratamie__6CFB22455B0F9260");

            entity.Property(e => e.TratamientoId).HasColumnName("TratamientoID");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798812E8809");

            entity.HasIndex(e => e.Usuario1, "UQ__Usuarios__E3237CF7F375B9CC").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__RolID__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
