using System.Collections.Generic;

namespace Practico2.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}

/*
 
Gestión de Roles
Propiedades a tener en cuenta:

Id: int, autoincrementable
Nombre: str, required

•	Deben existir por defecto dos roles ya ingresados: Administrador, Empleado
•	El único endpoint a tener en cuenta será ObtenerUsuariosPorRol
 
*/