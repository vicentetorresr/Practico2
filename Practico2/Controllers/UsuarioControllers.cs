using Microsoft.AspNetCore.Mvc;
using Practico2.Models;
using Practico2.Responses;
using Practico2.Services;
using System.Collections.Generic;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }

        [HttpGet("Obtener_Usuarios")]
        public ActionResult<UsuariosResponse> GetUsuarios()
        {
            // Llamamos al servicio para obtener la lista de usuarios
            var usuarios = _usuarioService.ListaUsuarios();

            var response = new UsuariosResponse
            {
                Data = usuarios,
                Code = 200,
                Message = "Usuarios obtenidos correctamente"
            };

            return Ok(response);
        }

        [HttpGet("Obtener_Usuario/{id}")]
        public ActionResult<UsuarioResponse> GetUsuario(int id)
        {
            // Obtener un usuario por su ID
            var usuario = _usuarioService.ObtenerUsuario(id);

            var response = new UsuarioResponse
            {
                Data = usuario,
                Code = 200,
                Message = "Usuario obtenido correctamente"
            };

            return Ok(response);
        }

        [HttpPost("Ingresar_Usuario")]
        public ActionResult<NuevoUsuarioResponse> PostUsuario([FromBody] Usuario usuario)
        {
            // Insertar un nuevo usuario
            var result = _usuarioService.IngresarUsuario(usuario);

            var response = new NuevoUsuarioResponse
            {
                Data = result,
                Code = 200,
                Message = "Usuario ingresado correctamente"
            };

            return Ok(response);
        }

        [HttpPut("Actualizar_Usuario/{id}")]
        public ActionResult<ActualizarUsuarioResponse> PutUsuario(int id, [FromBody] Usuario usuario)
        {
            // Actualizar un usuario existente
            var result = _usuarioService.ActualizarUsuario(id, usuario);

            var response = new ActualizarUsuarioResponse
            {
                Data = result,
                Code = 200,
                Message = "Usuario actualizado correctamente"
            };

            return Ok(response);
        }

        [HttpDelete("Eliminar_Usuario/{id}")]
        public ActionResult<EliminarUsuarioResponse> DeleteUsuario(int id)
        {
            // Eliminar un usuario existente
            var result = _usuarioService.EliminarUsuario(id);

            var response = new EliminarUsuarioResponse
            {
                Data = result,
                Code = 200,
                Message = "Usuario eliminado correctamente"
            };

            return Ok(response);
        }
    }
}
