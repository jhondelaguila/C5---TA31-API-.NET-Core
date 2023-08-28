using Microsoft.EntityFrameworkCore;
using ex1.Models;

namespace ex1.Data
{

    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("usuarios");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


