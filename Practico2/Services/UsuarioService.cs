using Practico2.Models;
using System.Collections.Generic;

namespace Practico2.Services
{
    public class UsuarioService
    {
        // Este m�todo devuelve la lista de usuarios de manera sincr�nica
        public List<Usuario> ListaUsuarios()
        {
            // Cargar los usuarios desde la clase Usuario (simulaci�n)
            return Usuario.CargarUsuarios();
        }

        // Obtener un solo usuario por su ID
        public Usuario ObtenerUsuario(int id)
        {
            // Simulaci�n de la obtenci�n de un usuario desde una base de datos
            return Usuario.CargarUsuario(); // Puedes reemplazar esto por una b�squeda real en una lista o DB
        }

        // Insertar un nuevo usuario (simulaci�n)
        public bool IngresarUsuario(Usuario usuario)
        {
            // Simulaci�n de la inserci�n de un nuevo usuario
            return true;
        }

        // Actualizar un usuario existente (simulaci�n)
        public bool ActualizarUsuario(int id, Usuario usuario)
        {
            // Simulaci�n de la actualizaci�n de un usuario
            return true;
        }

        // Eliminar un usuario existente (simulaci�n)
        public bool EliminarUsuario(int id)
        {
            // Simulaci�n de la eliminaci�n de un usuario
            return true;
        }
    }
}
