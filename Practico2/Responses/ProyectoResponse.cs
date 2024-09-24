using Practico2.Models;
using System.Threading;
namespace Practico2.Responses
{
    /*retorna un proyecto*/
    public class ProyectoResponse : ResponseBase<Proyecto>
    {
    }

    /*retorna una lista de proyectos*/
    public class ProyectosResponse : ResponseBase<List<Proyecto>>
    {
    }
    // retorna un boleano si se pudo crear un proyecto
    public class NuevoProyectoResponse : ResponseBase<bool>
    {
    }
    // retorna un boleano si se pudo actualizar un proyecto
    public class UpdateProyectoResponse : ResponseBase<bool>
    {
    }
    // retorna un boleano si se pudo eliminar un proyecto
    public class DeleteProyectoResponse : ResponseBase<bool>
    {
    }

}
