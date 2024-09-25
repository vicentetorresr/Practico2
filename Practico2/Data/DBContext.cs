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

            //Acá se pueden cargar los datos iniciales de la base de datos

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

        }

    }

}
