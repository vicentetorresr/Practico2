using Microsoft.AspNetCore.Mvc;
using Practico2.DTOs;
using Practico2.Models;
using Practico2.Responses;
using Practico2.Services;
using System.Threading.Tasks;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RolesService _rolesService;

        public RolesController()
        {
            _rolesService = new RolesService();
        }

        [HttpGet("Obtener_Usuarios_Por_Rol")]
        public async Task<ActionResult<RolesResponse>> GetRoles()
        {
            var roles = _rolesService.ListaRoles();

            var response = new RolesResponse
            {
                Data = roles,
                Code = 200,
                Message = "Roles obtenidos correctamente"
            };

            return Ok(response);
        }
    }
}
