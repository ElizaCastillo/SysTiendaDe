using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysTiendaDe.Models;

public partial class BDContext : DbContext
{
    public BDContext()
    {
    }

    public BDContext(DbContextOptions<BDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DBTienda135.mssql.somee.com;User ID=Rebe_SQLLogin_1;Password=aiuipz8e1w;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Factura_Cliente");

            entity.HasOne(d => d.Servicio).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Factura_Servicio");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasOne(d => d.Cliente).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
