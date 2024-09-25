using Practico2.Models;
using System.Collections.Generic;

namespace Practico2.Services
{
    public class UsuarioService
    {
        // Este método devuelve la lista de usuarios de manera sincrónica
        public List<Usuario> ListaUsuarios()
        {
            // Cargar los usuarios desde la clase Usuario (simulación)
            return Usuario.CargarUsuarios();
        }

        // Obtener un solo usuario por su ID
        public Usuario ObtenerUsuario(int id)
        {
            // Simulación de la obtención de un usuario desde una base de datos
            return Usuario.CargarUsuario(); // Puedes reemplazar esto por una búsqueda real en una lista o DB
        }

        // Insertar un nuevo usuario (simulación)
        public bool IngresarUsuario(Usuario usuario)
        {
            // Simulación de la inserción de un nuevo usuario
            return true;
        }

        // Actualizar un usuario existente (simulación)
        public bool ActualizarUsuario(int id, Usuario usuario)
        {
            // Simulación de la actualización de un usuario
            return true;
        }

        // Eliminar un usuario existente (simulación)
        public bool EliminarUsuario(int id)
        {
            // Simulación de la eliminación de un usuario
            return true;
        }
    }
}
