using Practico2.Models;
using System.Collections.Generic;

namespace Practico2.Responses
{
    /* Retorna un usuario */
    public class UsuarioResponse : ResponseBase<Usuario>
    {
    }

    /* Retorna una lista de usuarios */
    public class UsuariosResponse : ResponseBase<List<Usuario>>
    {
    }

    /* Retorna un booleano si se pudo crear un usuario */
    public class NuevoUsuarioResponse : ResponseBase<bool>
    {
    }

    /* Retorna un booleano si se pudo actualizar un usuario */
    public class UpdateUsuarioResponse : ResponseBase<bool>
    {
    }

    /* Retorna un booleano si se pudo eliminar un usuario */
    public class DeleteUsuarioResponse : ResponseBase<bool>
    {
    }
}
