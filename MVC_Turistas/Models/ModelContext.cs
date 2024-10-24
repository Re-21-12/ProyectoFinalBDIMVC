using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Turistas.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CorreoElectronico> CorreoElectronicos { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelTuristum> HotelTurista { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<SucursalTuristum> SucursalTurista { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    public virtual DbSet<Turistum> Turista { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    public virtual DbSet<VueloTuristum> VueloTurista { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("User Id=system;Password=Alfredo+123;Data Source=localhost:1521/xe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<CorreoElectronico>(entity =>
        {
            entity.HasKey(e => e.CorreoElectronico1).HasName("SYS_C008397");

            entity.ToTable("CORREO_ELECTRONICO");

            entity.Property(e => e.CorreoElectronico1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.CodigoTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_TURISTA");

            entity.HasOne(d => d.CodigoTuristaNavigation).WithMany(p => p.CorreoElectronicos)
                .HasForeignKey(d => d.CodigoTurista)
                .HasConstraintName("SYS_C008398");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.CodigoHotel).HasName("SYS_C008382");

            entity.ToTable("HOTEL");

            entity.Property(e => e.CodigoHotel)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_HOTEL");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CIUDAD");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroPlazasDisponibles)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMERO_PLAZAS_DISPONIBLES");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<HotelTuristum>(entity =>
        {
            entity.HasKey(e => e.CodigoHotelTurista).HasName("SYS_C008392");

            entity.ToTable("HOTEL_TURISTA");

            entity.Property(e => e.CodigoHotelTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_HOTEL_TURISTA");
            entity.Property(e => e.CodigoHotel)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_HOTEL");
            entity.Property(e => e.CodigoTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_TURISTA");
            entity.Property(e => e.FechaLlegada)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_LLEGADA");
            entity.Property(e => e.FechaPartida)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_PARTIDA");
            entity.Property(e => e.Regimen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("REGIMEN");

            entity.HasOne(d => d.CodigoHotelNavigation).WithMany(p => p.HotelTurista)
                .HasForeignKey(d => d.CodigoHotel)
                .HasConstraintName("SYS_C008393");

            entity.HasOne(d => d.CodigoTuristaNavigation).WithMany(p => p.HotelTurista)
                .HasForeignKey(d => d.CodigoTurista)
                .HasConstraintName("SYS_C008394");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.CodigoSucursal).HasName("SYS_C008380");

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.CodigoSucursal)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_SUCURSAL");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<SucursalTuristum>(entity =>
        {
            entity.HasKey(e => e.CodigoSucursalTurista).HasName("SYS_C008386");

            entity.ToTable("SUCURSAL_TURISTA");

            entity.Property(e => e.CodigoSucursalTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_SUCURSAL_TURISTA");
            entity.Property(e => e.CodigoSucursal)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_SUCURSAL");
            entity.Property(e => e.CodigoTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_TURISTA");

            entity.HasOne(d => d.CodigoSucursalNavigation).WithMany(p => p.SucursalTurista)
                .HasForeignKey(d => d.CodigoSucursal)
                .HasConstraintName("SYS_C008387");

            entity.HasOne(d => d.CodigoTuristaNavigation).WithMany(p => p.SucursalTurista)
                .HasForeignKey(d => d.CodigoTurista)
                .HasConstraintName("SYS_C008388");
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.HasKey(e => e.NumeroTelefono).HasName("SYS_C008395");

            entity.ToTable("TELEFONO");

            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NUMERO_TELEFONO");
            entity.Property(e => e.CodigoTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_TURISTA");

            entity.HasOne(d => d.CodigoTuristaNavigation).WithMany(p => p.Telefonos)
                .HasForeignKey(d => d.CodigoTurista)
                .HasConstraintName("SYS_C008396");
        });

        modelBuilder.Entity<Turistum>(entity =>
        {
            entity.HasKey(e => e.CodigoTurista).HasName("SYS_C008383");

            entity.ToTable("TURISTA");

            entity.Property(e => e.CodigoTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_TURISTA");
            entity.Property(e => e.ApellidoDos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_DOS");
            entity.Property(e => e.ApellidoUno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_UNO");
            entity.Property(e => e.CodigoSucursal)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_SUCURSAL");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.NombreDos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_DOS");
            entity.Property(e => e.NombreTres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TRES");
            entity.Property(e => e.NombreUno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_UNO");
            entity.Property(e => e.NumeroVuelo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMERO_VUELO");
            entity.Property(e => e.PaisResidencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAIS_RESIDENCIA");

            entity.HasOne(d => d.CodigoSucursalNavigation).WithMany(p => p.Turista)
                .HasForeignKey(d => d.CodigoSucursal)
                .HasConstraintName("SYS_C008385");

            entity.HasOne(d => d.NumeroVueloNavigation).WithMany(p => p.Turista)
                .HasForeignKey(d => d.NumeroVuelo)
                .HasConstraintName("SYS_C008384");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.NumeroVuelo).HasName("SYS_C008381");

            entity.ToTable("VUELO");

            entity.Property(e => e.NumeroVuelo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMERO_VUELO");
            entity.Property(e => e.Destino)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESTINO");
            entity.Property(e => e.Fecha)
                .HasColumnType("DATE")
                .HasColumnName("FECHA");
            entity.Property(e => e.Hora)
                .HasPrecision(6)
                .HasColumnName("HORA");
            entity.Property(e => e.Origen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORIGEN");
            entity.Property(e => e.PlazaTotales)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PLAZA_TOTALES");
            entity.Property(e => e.PlazaTuristaDisponible)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PLAZA_TURISTA_DISPONIBLE");
        });

        modelBuilder.Entity<VueloTuristum>(entity =>
        {
            entity.HasKey(e => e.NumeroVueloTurista).HasName("SYS_C008389");

            entity.ToTable("VUELO_TURISTA");

            entity.Property(e => e.NumeroVueloTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMERO_VUELO_TURISTA");
            entity.Property(e => e.Clase)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASE");
            entity.Property(e => e.CodigoTurista)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_TURISTA");
            entity.Property(e => e.NumeroVuelo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMERO_VUELO");

            entity.HasOne(d => d.CodigoTuristaNavigation).WithMany(p => p.VueloTurista)
                .HasForeignKey(d => d.CodigoTurista)
                .HasConstraintName("SYS_C008391");

            entity.HasOne(d => d.NumeroVueloNavigation).WithMany(p => p.VueloTurista)
                .HasForeignKey(d => d.NumeroVuelo)
                .HasConstraintName("SYS_C008390");
        });
        modelBuilder.HasSequence("LOGMNR_DIDS$");
        modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");
        modelBuilder.HasSequence("LOGMNR_SEQ$");
        modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");
        modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
