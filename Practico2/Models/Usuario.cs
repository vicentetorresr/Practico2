using Practico2.Models;

namespace Practico2.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public Roles Rol { get; set; } 

        // Simulación de la carga de un usuario de prueba
        public static Usuario CargarUsuario()
        {
            return new Usuario
            {
                Id = 1,
                Nombre = "Angelo Maureira",
                Email = "Angelo@example.com",
                Password = "123456",
                RolId = 1 // Se referencia el rol aca con el rolid
            };
        }
        public static List<Usuario> CargarUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    Nombre = "Angelo Maureira",
                    Email = "Angelo@example.com",
                    Password = "123456",
                    RolId = 1 // Administrador
                }               
            };
        }
    }
}

