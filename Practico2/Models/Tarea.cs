using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practico2.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El estado de la tarea es obligatorio.")]
        [RegularExpression(@"^(Pendiente|En progreso|Finalizado)$", ErrorMessage = "Estado no válido.")]
        public string EstadoTarea { get; set; }

        [Required(ErrorMessage = "Las horas son obligatorias.")]
        [Range(1, int.MaxValue, ErrorMessage = "Las horas deben ser al menos 1.")]
        public int Horas { get; set; }

        [Required(ErrorMessage = "El área es obligatoria.")]
        [RegularExpression(@"^(Hardware|Redes)$", ErrorMessage = "Área no válida.")]
        public string Area { get; set; }

        [Required(ErrorMessage = "El ID del proyecto es obligatorio.")]
        public int IdProyecto { get; set; }

        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El set de herramientas es obligatorio.")]
        public string SetHerramientas { get; set; }

    }
}

/*
 Gestión de tareas 
Propiedades a tener en cuenta:

Id: int, autoincrementable
Fecha de inicio: date, required
Estado: str, required, valores aceptados = “Pendiente”, “En progreso”, “Finalizado”
Horas: int, required, valor mínimo = 1
Área:  str, required, valores aceptados = “Hardware”, “Redes”
Proyecto: FK de proyecto
Empleado asignado: FK de Usuarios
Set herramientas: str

•	Los endpoints a tener en cuenta son los relativos al CRUD.
•	Debe controlar que no se ingrese un nombre de área no existente
•	Debe controlar que el valor de las horas no sea menor a 1
•	Debe controlar que no se ingrese un nombre de estado no existente.
•	Debe controlar que no se ingrese un proyecto y un empleado inexistente.
•	El set de herramientas debe ser una cadena de texto que separe por comas cada uno de los id de herramientas que se utilizarán en la tarea. Debe controlarse que cada uno de los id ingresados exista dentro de la tabla herramientas.

 */