using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sem9.Models;

public partial class TesisContext : DbContext
{
    public TesisContext()
    {
    }

    public TesisContext(DbContextOptions<TesisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asesor> Asesors { get; set; }

    public virtual DbSet<AsignarAsesor> AsignarAsesors { get; set; }

    public virtual DbSet<AsignarEstudiante> AsignarEstudiantes { get; set; }

    public virtual DbSet<AsignarJurado> AsignarJurados { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Jurado> Jurados { get; set; }

    public virtual DbSet<PagoCarpeta> PagoCarpeta { get; set; }

    public virtual DbSet<SolicitudTesis> SolicitudTeses { get; set; }

    public virtual DbSet<SustentacionFinal> SustentacionFinals { get; set; }

    public virtual DbSet<Tesis> Teses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asesor>(entity =>
        {
            entity.HasKey(e => e.IdAsesor).HasName("PK__ASESOR__A801FCE9550BEADD");

            entity.ToTable("ASESOR");

            entity.Property(e => e.IdAsesor)
                .ValueGeneratedNever()
                .HasColumnName("idAsesor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Carrera)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("carrera");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<AsignarAsesor>(entity =>
        {
            entity.HasKey(e => e.IdAsignar).HasName("PK__ASIGNAR___8319E6556D1245BF");

            entity.ToTable("ASIGNAR_ASESOR");

            entity.Property(e => e.IdAsignar)
                .ValueGeneratedNever()
                .HasColumnName("idAsignar");
            entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");
            entity.Property(e => e.IdTesis).HasColumnName("idTesis");

            entity.HasOne(d => d.IdAsesorNavigation).WithMany(p => p.AsignarAsesors)
                .HasForeignKey(d => d.IdAsesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_A__idAse__44FF419A");

            entity.HasOne(d => d.IdTesisNavigation).WithMany(p => p.AsignarAsesors)
                .HasForeignKey(d => d.IdTesis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_A__idTes__440B1D61");
        });

        modelBuilder.Entity<AsignarEstudiante>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__ASIGNAR___E17144781DF73DD8");

            entity.ToTable("ASIGNAR_ESTUDIANTE");

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("idAsignacion");
            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");
            entity.Property(e => e.IdTesis).HasColumnName("idTesis");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.AsignarEstudiantes)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_E__idEst__412EB0B6");

            entity.HasOne(d => d.IdTesisNavigation).WithMany(p => p.AsignarEstudiantes)
                .HasForeignKey(d => d.IdTesis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_E__idTes__403A8C7D");
        });

        modelBuilder.Entity<AsignarJurado>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__ASIGNAR___E1714478BA6D2F3A");

            entity.ToTable("ASIGNAR_JURADO");

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("idAsignacion");
            entity.Property(e => e.IdJurado).HasColumnName("idJurado");
            entity.Property(e => e.IdSustentacion).HasColumnName("idSustentacion");

            entity.HasOne(d => d.IdJuradoNavigation).WithMany(p => p.AsignarJurados)
                .HasForeignKey(d => d.IdJurado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_J__idJur__5165187F");

            entity.HasOne(d => d.IdSustentacionNavigation).WithMany(p => p.AsignarJurados)
                .HasForeignKey(d => d.IdSustentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_J__idSus__5070F446");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__ESTUDIAN__AEFFDBC50AAD64AA");

            entity.ToTable("ESTUDIANTE");

            entity.Property(e => e.IdEstudiante)
                .ValueGeneratedNever()
                .HasColumnName("idEstudiante");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Carrera)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("carrera");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Jurado>(entity =>
        {
            entity.HasKey(e => e.IdJurado).HasName("PK__JURADO__778A32DEAF695123");

            entity.ToTable("JURADO");

            entity.Property(e => e.IdJurado)
                .ValueGeneratedNever()
                .HasColumnName("idJurado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Carrera)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("carrera");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<PagoCarpeta>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__PAGO_CAR__BD2295AD2DB412E0");

            entity.ToTable("PAGO_CARPETA");

            entity.Property(e => e.IdPago)
                .ValueGeneratedNever()
                .HasColumnName("idPago");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("metodoPago");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.PagoCarpeta)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PAGO_CARP__idEst__47DBAE45");
        });

        modelBuilder.Entity<SolicitudTesis>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__SOLICITU__D801DDB8210A1D2F");

            entity.ToTable("SOLICITUD_TESIS");

            entity.Property(e => e.IdSolicitud)
                .ValueGeneratedNever()
                .HasColumnName("idSolicitud");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdPago).HasColumnName("idPago");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.SolicitudTesis)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SOLICITUD__idPag__4AB81AF0");
        });

        modelBuilder.Entity<SustentacionFinal>(entity =>
        {
            entity.HasKey(e => e.IdSustentacion).HasName("PK__SUSTENTA__F5B1C0083188C7C2");

            entity.ToTable("SUSTENTACION_FINAL");

            entity.Property(e => e.IdSustentacion)
                .ValueGeneratedNever()
                .HasColumnName("idSustentacion");
            entity.Property(e => e.Calificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calificacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdTesis).HasColumnName("idTesis");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modalidad");

            entity.HasOne(d => d.IdTesisNavigation).WithMany(p => p.SustentacionFinals)
                .HasForeignKey(d => d.IdTesis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SUSTENTAC__idTes__4D94879B");
        });

        modelBuilder.Entity<Tesis>(entity =>
        {
            entity.HasKey(e => e.IdTesis).HasName("PK__TESIS__2E2073ED92DF67BA");

            entity.ToTable("TESIS");

            entity.Property(e => e.IdTesis)
                .ValueGeneratedNever()
                .HasColumnName("idTesis");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");
            entity.Property(e => e.LineaInvestigacion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("lineaInvestigacion");
            entity.Property(e => e.Objetivo)
                .HasColumnType("text")
                .HasColumnName("objetivo");
            entity.Property(e => e.TipoTesis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoTesis");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Tesis)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TESIS__idEstudia__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
