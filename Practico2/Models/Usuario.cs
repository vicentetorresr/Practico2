using Practico2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico2.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

     

        [ForeignKey("Rol")]
        public int RolId { get; set; }
    }
}

/*
 Gesti�n de usuarios
Propiedades a tener en cuenta:

Id: int, autoincrementable
Nombre: str
Email: str
Password: str
Rol: id (FK roles)

�	Los endpoints a tener en cuenta son los relativos al CRUD.
�	Debe controlar que no se ingrese un usuario con un rol no existente

 */