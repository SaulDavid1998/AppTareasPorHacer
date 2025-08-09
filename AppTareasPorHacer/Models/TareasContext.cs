using Microsoft.EntityFrameworkCore;

namespace AppTareasPorHacer.Models
{
    public class TareasContext : DbContext
    {

        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
        }
        public DbSet<Tarea> Tarea { get; set; } = null!;
        public DbSet<Categoria> Categoria { get; set; } = null!;
        public DbSet<Estado> Estado { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId="hogar", CategoriaNombre="Hogar" },
                new Categoria { CategoriaId="trabajo", CategoriaNombre="Trabajo" },
                new Categoria { CategoriaId="estudio", CategoriaNombre="Estudio" },
                new Categoria { CategoriaId="ocio", CategoriaNombre="Ocio" }
            );

            modelBuilder.Entity<Estado>().HasData(
                new Estado { EstadoId = "pendiente", EstadoNombre = "Pendiente" },
                new Estado { EstadoId = "completada", EstadoNombre = "Completada" }
            );

        }

    }
}
