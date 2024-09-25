namespace Practico2.DTOs
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; } // Relación con el Rol
    }
}
