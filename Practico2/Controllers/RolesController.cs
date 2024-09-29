using Microsoft.AspNetCore.Mvc;
using Practico2.Data;
using Practico2.Responses;
using Practico2.Services;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RolesService _rolesService;

        public RolesController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EjemploDbContext>();
            _rolesService = new RolesService(context);
        }

        // Obtener un usuario por su ID
        [HttpGet("show/{id}")]
        public async Task<ActionResult<RolesResponse>> GetRol(int id)
        {
            var rol = await _rolesService.ObtenerRolPorIdAsync(id);

            if (rol == null)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Rol no encontrado"
                });
            }

            return Ok(new RolesResponse
            {
                Data = rol,
                Code = 200,
                Message = "Rol obtenido correctamente"
            });
        }
    }
}
