using Microsoft.EntityFrameworkCore;
using Practico2.Models;

namespace Practico2.Data
{
    public class EjemploDbContext : DbContext
    {
        public EjemploDbContext(DbContextOptions<EjemploDbContext> options) : base(options)
        {
        }

        /* DbSet indica el modelo que se va a mapear (reflejar) a la base de datos */
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Herramientas> Herramientas { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales para Roles
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Nombre = "Administrador"
            });

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 2,
                Nombre = "Empleado"
            });


            // Datos iniciales para Usuarios
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Email = "juan@juan.cl",
                Password = "1234",
                RolId = 1
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                Nombre = "Pedro",
                Apellido = "Perez",
                Email = "pedro@pedro.cl",
                Password = "1234",
                RolId = 2
            });

        }

    }

}
