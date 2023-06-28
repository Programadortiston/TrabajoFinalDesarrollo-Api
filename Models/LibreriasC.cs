using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibreria.Models;

public partial class LibreriasC : DbContext
{
    public LibreriasC()
    {
    }

    public LibreriasC(DbContextOptions<LibreriasC> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleReserva> TbDetalleReservas { get; set; }

    public virtual DbSet<TbLibro> TbLibros { get; set; }

    public virtual DbSet<TbLogin> TbLogins { get; set; }

    public virtual DbSet<TbReserva> TbReservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sql5106.site4now.net;Initial Catalog=db_a9b33e_biblio;User ID= db_a9b33e_biblio_admin;Password=t7.ZU*T8qQ9$XNH;Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_ADMIN");

            entity.Property(e => e.ContraAdmin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CONTRA_ADMIN");
            entity.Property(e => e.UserAdmin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USER_ADMIN");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCli).HasName("PK__TB_CLIEN__2BF8836D6F99BE8E");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.IdCli).HasColumnName("ID_CLI");
            entity.Property(e => e.ApeCli)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APE_CLI");
            entity.Property(e => e.NomCli)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOM_CLI");
        });

        modelBuilder.Entity<TbDetalleReserva>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__TB_DETAL__B4F46A57273F0127");

            entity.ToTable("TB_DETALLE_RESERVA");

            entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.FecDevolucion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FEC_DEVOLUCION");
            entity.Property(e => e.FecPrestamo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FEC_PRESTAMO");
            entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");
            entity.Property(e => e.IdPrestamo).HasColumnName("ID_PRESTAMO");

            

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.TbDetalleReservas)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__ID_PR__412EB0B6");
        });

        modelBuilder.Entity<TbLibro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__TB_LIBRO__93FF0A064AE35F26");

            entity.ToTable("TB_LIBRO");

            entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AUTOR");
            entity.Property(e => e.Año).HasColumnName("AÑO");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GENERO");
            entity.Property(e => e.Link)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("LINK");
            entity.Property(e => e.Stock).HasColumnName("STOCK");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITULO");
        });

        modelBuilder.Entity<TbLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_LOGIN");

            entity.Property(e => e.Contra)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CONTRA");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USUARIO");
        });

        modelBuilder.Entity<TbReserva>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__TB_RESER__3D5A1E6C7B46B121");

            entity.ToTable("TB_RESERVA");

            entity.Property(e => e.IdPrestamo).HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FecDevolucion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FEC_DEVOLUCION");
            entity.Property(e => e.FecPrestamo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FEC_PRESTAMO");
            entity.Property(e => e.IdCli).HasColumnName("ID_CLI");

            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
