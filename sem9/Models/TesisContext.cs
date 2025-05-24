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
            entity.HasKey(e => e.IdAsesor).HasName("PK__ASESOR__A801FCE94992E17D");

            entity.ToTable("ASESOR");

            entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");
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

        modelBuilder.Entity<AsignarEstudiante>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__ASIGNAR___E1714478FA2194F7");

            entity.ToTable("ASIGNAR_ESTUDIANTE");

            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");
            entity.Property(e => e.IdTesis).HasColumnName("idTesis");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.AsignarEstudiantes)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_E__idEst__4222D4EF");

            entity.HasOne(d => d.IdTesisNavigation).WithMany(p => p.AsignarEstudiantes)
                .HasForeignKey(d => d.IdTesis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_E__idTes__412EB0B6");
        });

        modelBuilder.Entity<AsignarJurado>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__ASIGNAR___E17144787D545FCE");

            entity.ToTable("ASIGNAR_JURADO");

            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.IdJurado).HasColumnName("idJurado");
            entity.Property(e => e.IdSustentacion).HasColumnName("idSustentacion");

            entity.HasOne(d => d.IdJuradoNavigation).WithMany(p => p.AsignarJurados)
                .HasForeignKey(d => d.IdJurado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_J__idJur__4E88ABD4");

            entity.HasOne(d => d.IdSustentacionNavigation).WithMany(p => p.AsignarJurados)
                .HasForeignKey(d => d.IdSustentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNAR_J__idSus__4D94879B");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__ESTUDIAN__AEFFDBC596EDFDBA");

            entity.ToTable("ESTUDIANTE");

            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");
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
            entity.HasKey(e => e.IdJurado).HasName("PK__JURADO__778A32DE523CF6DE");

            entity.ToTable("JURADO");

            entity.Property(e => e.IdJurado).HasColumnName("idJurado");
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
            entity.HasKey(e => e.IdPago).HasName("PK__PAGO_CAR__BD2295AD2F8D773D");

            entity.ToTable("PAGO_CARPETA");

            entity.Property(e => e.IdPago).HasColumnName("idPago");
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
                .HasConstraintName("FK__PAGO_CARP__idEst__44FF419A");
        });

        modelBuilder.Entity<SolicitudTesis>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__SOLICITU__D801DDB8CA4EC946");

            entity.ToTable("SOLICITUD_TESIS");

            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdPago).HasColumnName("idPago");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.SolicitudTesis)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SOLICITUD__idPag__47DBAE45");
        });

        modelBuilder.Entity<SustentacionFinal>(entity =>
        {
            entity.HasKey(e => e.IdSustentacion).HasName("PK__SUSTENTA__F5B1C0086D917A78");

            entity.ToTable("SUSTENTACION_FINAL");

            entity.Property(e => e.IdSustentacion).HasColumnName("idSustentacion");
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
                .HasConstraintName("FK__SUSTENTAC__idTes__4AB81AF0");
        });

        modelBuilder.Entity<Tesis>(entity =>
        {
            entity.HasKey(e => e.IdTesis).HasName("PK__TESIS__2E2073ED2BDB88FE");

            entity.ToTable("TESIS");

            entity.Property(e => e.IdTesis).HasColumnName("idTesis");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");
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

            entity.HasOne(d => d.IdAsesorNavigation).WithMany(p => p.Tesis)
                .HasForeignKey(d => d.IdAsesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TESIS__idAsesor__3E52440B");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Tesis)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TESIS__idEstudia__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
