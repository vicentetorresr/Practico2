namespace Practico2.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; } // valores aceptados: "Pendiente", "En progreso", "Finalizado"
        public int HorasTrabajadas { get; set; } = 0; // Por defecto = 0
        public int HorasTotales { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

/*
 Gestión de Proyectos
Propiedades a tener en cuenta:

Id: int, autoincrementable
Nombre: str, required
Descripción: str, required
Estado: str, required, valores aceptados = “Pendiente”, “En progreso”, “Finalizado”
Horas Trabajadas: int, por defecto = 0, 
Horas Totales: int, required,
Fecha creación: date, required

•	Debe controlar que en estado no se ingrese un valor distinto a los permitidos.
•	Las horas trabajadas siempre deben tener valor 0.
•	La fecha de creación siempre debe ser definida por la aplicación como la fecha actual.
•	Los endpoints a tener en cuenta son los relativos al CRUD.

 */