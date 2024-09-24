using System.Collections.Generic;

namespace Practico2.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Método para cargar una lista de roles
        public static List<Roles> CargarRoles()
        {
            return new List<Roles>
            {
                new Roles
                {
                    Id = 1,
                    Name = "Administrador",
                },
                new Roles
                {
                    Id = 2,
                    Name = "Empleado",
                }
            };
        }
    }
}
