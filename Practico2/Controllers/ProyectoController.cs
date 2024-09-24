using Microsoft.AspNetCore.Mvc;
using Practico2.DTOs;
using Practico2.Models;
using Practico2.Services;
using Practico2.Responses;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;

        public ProyectoController(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;
        }

        // GET: api/proyecto/index
        [HttpGet("index")]
        public async Task<ActionResult<ProyectosResponse>> Index()
        {
            var proyectos = await _proyectoService.Index();

            if (proyectos == null || proyectos.Count == 0)
            {
                return NotFound(new ProyectosResponse
                {
                    Code = 404,
                    Message = "No se encontraron proyectos"
                });
            }

            return Ok(new ProyectosResponse
            {
                Code = 200,
                Message = "Proyectos obtenidos correctamente",
                Data = proyectos
            });
        }

        // GET: api/proyecto/show/{id}
        [HttpGet("show/{id}")]
        public async Task<ActionResult<ProyectoResponse>> Show(int id)
        {
            var proyecto = await _proyectoService.Show(id);

            if (proyecto == null)
            {
                return NotFound(new ProyectoResponse
                {
                    Code = 404,
                    Message = $"El proyecto con ID {id} no fue encontrado"
                });
            }

            return Ok(new ProyectoResponse
            {
                Code = 200,
                Message = "Proyecto obtenido correctamente",
                Data = proyecto
            });
        }

        // POST: api/proyecto/create
        [HttpPost("create")]
        public async Task<ActionResult<NuevoProyectoResponse>> Create([FromBody] ProyectoDTO proyectoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new NuevoProyectoResponse
                {
                    Code = 400,
                    Message = "Datos inválidos",
                    Data = false
                });
            }

            var result = await _proyectoService.Create(proyectoDTO);

            if (!result)
            {
                return StatusCode(500, new NuevoProyectoResponse
                {
                    Code = 500,
                    Message = "Error al crear el proyecto",
                    Data = false
                });
            }

            return Ok(new NuevoProyectoResponse
            {
                Code = 201,
                Message = "Proyecto creado correctamente",
                Data = true
            });
        }

        // PUT: api/proyecto/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<UpdateProyectoResponse>> Update(int id, [FromBody] ProyectoDTO proyectoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new UpdateProyectoResponse
                {
                    Code = 400,
                    Message = "Datos inválidos",
                    Data = false
                });
            }

            var result = await _proyectoService.Update(id, proyectoDTO);

            if (!result)
            {
                return NotFound(new UpdateProyectoResponse
                {
                    Code = 404,
                    Message = $"El proyecto con ID {id} no fue encontrado",
                    Data = false
                });
            }

            return Ok(new UpdateProyectoResponse
            {
                Code = 200,
                Message = "Proyecto actualizado correctamente",
                Data = true
            });
        }

        // DELETE: api/proyecto/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<DeleteProyectoResponse>> Delete(int id)
        {
            var result = await _proyectoService.Delete(id);

            if (!result)
            {
                return NotFound(new DeleteProyectoResponse
                {
                    Code = 404,
                    Message = $"El proyecto con ID {id} no fue encontrado",
                    Data = false
                });
            }

            return Ok(new DeleteProyectoResponse
            {
                Code = 200,
                Message = "Proyecto eliminado correctamente",
                Data = true
            });
        }
    }
}
