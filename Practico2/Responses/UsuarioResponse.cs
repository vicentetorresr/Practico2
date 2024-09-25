using Practico2.Models;

namespace Practico2.Responses
{
    public class UsuarioResponse : ResponseBase<Usuario> { }

    public class UsuariosResponse : ResponseBase<List<Usuario>> { }

    public class NuevoUsuarioResponse : ResponseBase<bool> { }

    public class EliminarUsuarioResponse : ResponseBase<bool> { }

    public class ActualizarUsuarioResponse : ResponseBase<bool> { }
}