using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEnd.Domains.Models;

#nullable disable

namespace BackEnd.Persistence.Context
{
    public partial class OpheliaDbContext : DbContext
    {
        public OpheliaDbContext()
        {
        }

        public OpheliaDbContext(DbContextOptions<OpheliaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<Entrada> Entrada { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Salidum> Salida { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.CliApellidos).IsUnicode(false);

                entity.Property(e => e.CliIdentificacion).IsUnicode(false);

                entity.Property(e => e.CliNombres).IsUnicode(false);

                entity.Property(e => e.CliTipoIdentificacion).IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasOne(d => d.DetfacIdFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.DetfacIdFactura)
                    .HasConstraintName("FK_DETALLE_FACTURA_FACTURA");

                entity.HasOne(d => d.DetfacIdProductoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.DetfacIdProducto)
                    .HasConstraintName("FK_DETALLE_FACTURA_PRODUCTO");
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.HasOne(d => d.EntIdProductoNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.EntIdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTRADA_PRODUCTO");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasOne(d => d.FacIdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.FacIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACTURA_CLIENTE");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProNombre).IsUnicode(false);
            });

            modelBuilder.Entity<Salidum>(entity =>
            {
                entity.HasOne(d => d.SalIdProductoNavigation)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.SalIdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALIDA_PRODUCTO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
