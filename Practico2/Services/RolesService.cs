using Practico2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practico2.Services
{
    public class RolesService
    {
        // Cambiado a un método sincrónico si no hay operaciones asincrónicas reales
        public List<Roles> ListaRoles()
        {
            // Cargar los roles desde la clase Roles
            List<Roles> roles = Roles.CargarRoles();

            return roles;
        }
    }
}
