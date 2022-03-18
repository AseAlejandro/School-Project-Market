using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FIMEFavor.Models.Models;


namespace FIMEFavor.DAL.EF
{
    public class FimeContext : DbContext
    {
        public FimeContext()
        {

        }

        public FimeContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
               //@"Server=tcp:fimefavor.database.windows.net,1433;Initial Catalog=FimeFavor1;Persist Security Info=False;User ID=Usuario;Password=FimeFavor12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
               @"Server=(local);Database=FIME;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mochila>(entity =>
            {
                entity.Property(e => e.CostoTotal)
                    .HasColumnType("money")
                    .HasComputedColumnSql("[Cantidad]*[Precio]");
                entity.Property(e => e.Precio)
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio)
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Mochila>(entity =>
            {
                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
                entity.Property(e => e.Cantidad)
                    .HasDefaultValue(1);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasComputedColumnSql("FIME.GetOrdenTotal([Id])");
            });
        }

        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetallesOrden> DetallesOrdenes { get; set; }
        public DbSet<Mochila> Mochilas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
    }
}
