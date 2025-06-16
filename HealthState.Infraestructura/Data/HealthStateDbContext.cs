using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthState.Infraestructura.Data;

public partial class HealthStateDbContext : DbContext
{
    public HealthStateDbContext()
    {
    }

    public HealthStateDbContext(DbContextOptions<HealthStateDbContext> options)
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4PQ72NJ\\SQLEXPRESS;Database=HealthState; TrustServerCertificate=True; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aseguradora>(entity =>
        {
            entity.HasKey(e => e.AseguradoraId).HasName("PK__Asegurad__283AECB6BA005AE6");

            entity.Property(e => e.AseguradoraId)
                .ValueGeneratedNever()
                .HasColumnName("AseguradoraID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F23E931C2A");

            entity.Property(e => e.CitaId)
                .ValueGeneratedNever()
                .HasColumnName("CitaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.MedicoId).HasColumnName("MedicoID");
            entity.Property(e => e.MotivoConsulta).HasMaxLength(200);
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

            entity.HasOne(d => d.Estado).WithMany(p => p.Cita)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Citas__EstadoID__46E78A0C");

            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__Citas__MedicoID__45F365D3");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Citas__PacienteI__44FF419A");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleF__6E19D6FAE271FC43");

            entity.Property(e => e.DetalleId)
                .ValueGeneratedNever()
                .HasColumnName("DetalleID");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TratamientoId).HasColumnName("TratamientoID");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__DetalleFa__Factu__4F7CD00D");

            entity.HasOne(d => d.Tratamiento).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.TratamientoId)
                .HasConstraintName("FK__DetalleFa__Trata__5070F446");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estados__FEF86B60B7F21EFD");

            entity.Property(e => e.EstadoId)
                .ValueGeneratedNever()
                .HasColumnName("EstadoID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805B44FBEA6");

            entity.Property(e => e.FacturaId)
                .ValueGeneratedNever()
                .HasColumnName("FacturaID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Facturas__Pacien__4CA06362");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.MedicoId).HasName("PK__Medicos__5953C27653018D68");

            entity.Property(e => e.MedicoId)
                .ValueGeneratedNever()
                .HasColumnName("MedicoID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__Paciente__9353C07F8A929E95");

            entity.Property(e => e.PacienteId)
                .ValueGeneratedNever()
                .HasColumnName("PacienteID");
            entity.Property(e => e.AseguradoraId).HasColumnName("AseguradoraID");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PolizaId).HasColumnName("PolizaID");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Aseguradora).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.AseguradoraId)
                .HasConstraintName("FK__Pacientes__Asegu__403A8C7D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1EAE1691C");

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasColumnName("RolID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA77F56E477");

            entity.Property(e => e.SolicitudId)
                .ValueGeneratedNever()
                .HasColumnName("SolicitudID");
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
                .HasConstraintName("FK__Solicitud__Asegu__5812160E");

            entity.HasOne(d => d.Estado).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Solicitud__Estad__5535A963");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Solicitud__Pacie__571DF1D5");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__Solicitud__TipoI__5629CD9C");
        });

        modelBuilder.Entity<TipoSolicitude>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__TipoSoli__97099E97D9FBB78F");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("TipoID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.TratamientoId).HasName("PK__Tratamie__6CFB22454B385FE1");

            entity.Property(e => e.TratamientoId)
                .ValueGeneratedNever()
                .HasColumnName("TratamientoID");
            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(200);

            entity.HasOne(d => d.Cita).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK__Tratamien__CitaI__49C3F6B7");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7982709C239");

            entity.HasIndex(e => e.Nombre, "UQ__Usuarios__75E3EFCF92E92ACA").IsUnique();

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Salt).HasMaxLength(64);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__RolID__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
