using System;
using System.ComponentModel.DataAnnotations;

namespace Practico2.DTOs
{
    public class TareaDTO
    {

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
