using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Practico2.DTOs;
using Practico2.Models;
using Practico2.Services;
using Practico2.Data;
using Practico2.Responses; // Asegúrate de tener las respuestas adecuadas
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HerramientaController : Controller
    {
        private readonly HerramientaService _herramientaService;

        public HerramientaController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EjemploDbContext>();
            _herramientaService = new HerramientaService(context);
        }

        // Obtener todas las herramientas
        [HttpGet("index")]
        public async Task<ActionResult<List<Herramientas>>> GetHerramientas()
        {
            var herramientas = await _herramientaService.ObtenerHerramientasAsync();
            return Ok(new
            {
                Data = herramientas,
                Code = 200,
                Message = "Herramientas obtenidas correctamente"
            });
        }

        // Obtener una herramienta por su ID
        [HttpGet("show/{id}")]
        public async Task<ActionResult<Herramientas>> GetHerramienta(int id)
        {
            var herramienta = await _herramientaService.ObtenerHerramientaPorIdAsync(id);

            if (herramienta == null)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Herramienta no encontrada"
                });
            }

            return Ok(new
            {
                Data = herramienta,
                Code = 200,
                Message = "Herramienta obtenida correctamente"
            });
        }

        // Crear una nueva herramienta
        [HttpPost("create")]
        public async Task<ActionResult<Herramientas>> CrearHerramienta([FromBody] HerramientasDTO herramientaDTO)
        {
            var nuevaHerramienta = new Herramientas
            {
                Nombre = herramientaDTO.Nombre
            };

            await _herramientaService.CrearHerramientaAsync(nuevaHerramienta);

            return Ok(new
            {
                Data = nuevaHerramienta,
                Code = 200,
                Message = "Herramienta creada correctamente"
            });
        }

        // Actualizar una herramienta
        [HttpPut("update/{id}")]
        public async Task<ActionResult<bool>> ActualizarHerramienta(int id, [FromBody] HerramientasDTO herramientaDTO)
        {
            var actualizado = await _herramientaService.ActualizarHerramientaAsync(id, new Herramientas
            {
                Nombre = herramientaDTO.Nombre
            });

            if (!actualizado)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Herramienta no encontrada"
                });
            }

            return Ok(new
            {
                Data = true,
                Code = 200,
                Message = "Herramienta actualizada correctamente"
            });
        }

        // Eliminar una herramienta
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> EliminarHerramienta(int id)
        {
            var eliminado = await _herramientaService.EliminarHerramientaAsync(id);

            if (!eliminado)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Herramienta no encontrada"
                });
            }

            return Ok(new
            {
                Data = true,
                Code = 200,
                Message = "Herramienta eliminada correctamente"
            });
        }
    }
}
