using Practico2.Models;

namespace Practico2.Responses
{

    /* Retorna un Tarea */
    public class TareaResponse : ResponseBase<Tarea>
    {
    }

    /* Retorna una lista de Tareas */
    public class TareasResponse : ResponseBase<List<Tarea>>
    {
    }

    /* Retorna un booleano si se pudo crear un Tarea */
    public class NuevaTareaResponse : ResponseBase<bool>
    {
    }

    /* Retorna un booleano si se pudo actualizar un Tarea */
    public class UpdateTareaResponse : ResponseBase<bool>
    {
    }

    /* Retorna un booleano si se pudo eliminar un Tarea */
    public class DeleteTareaResponse : ResponseBase<bool>
    {
    }

}
