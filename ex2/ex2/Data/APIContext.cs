using Microsoft.EntityFrameworkCore;
using ex2.Models;

namespace ex2.Data
{

    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.Property(e => e.Nombre)
                        .HasMaxLength(250)
                        .HasColumnName("nombre");

                entity.Property(e => e.Apellido)
                        .HasMaxLength(250)
                        .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                        .HasMaxLength(250)
                        .HasColumnName("direccion");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("videos");

                entity.Property(e => e.Title)
                        .HasMaxLength(250)
                        .HasColumnName("title");

                entity.Property(e => e.Director)
                        .HasMaxLength(250)
                        .HasColumnName("director");

                entity.Property(e => e.Cli_id)
                       .HasColumnName("cli_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}