using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ex3.Models;

namespace ex3.Data;

public partial class APIContext : DbContext
{
    public APIContext(DbContextOptions<APIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cientifico> Cientificos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cientifico>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PRIMARY");

            entity.ToTable("cientificos");

            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni");
            entity.Property(e => e.NomApels)
                .HasMaxLength(255)
                .HasColumnName("nomApels");

            entity.HasMany(d => d.Proyectos).WithMany(p => p.Cientificos)
                .UsingEntity<Dictionary<string, object>>(
                    "AsignadoA",
                    r => r.HasOne<Proyecto>().WithMany()
                        .HasForeignKey("Proyecto")
                        .HasConstraintName("asignado_a_ibfk_2"),
                    l => l.HasOne<Cientifico>().WithMany()
                        .HasForeignKey("Cientifico")
                        .HasConstraintName("asignado_a_ibfk_1"),
                    j =>
                    {
                        j.HasKey("Cientifico", "Proyecto")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("asignado_a");
                        j.HasIndex(new[] { "Proyecto" }, "proyecto");
                        j.IndexerProperty<string>("Cientifico")
                            .HasMaxLength(8)
                            .HasColumnName("cientifico");
                        j.IndexerProperty<int>("Proyecto")
                            .HasColumnType("int(11)")
                            .HasColumnName("proyecto");
                    });
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proyectos");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Horas)
                .HasColumnType("int(11)")
                .HasColumnName("horas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
