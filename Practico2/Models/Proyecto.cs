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
