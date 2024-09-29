using Microsoft.EntityFrameworkCore;
using Practico2.Data;
using Practico2.DTOs;
using Practico2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practico2.Services
{
    public class ProyectoService
    {
        private readonly EjemploDbContext _dbContext;

        public ProyectoService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Crear un nuevo proyecto
        public async Task<Proyecto> CrearProyectoAsync(ProyectoDTO proyectoDTO)
        {
            var proyecto = new Proyecto
            {
                Nombre = proyectoDTO.Nombre,
                Descripcion = proyectoDTO.Descripcion,
                HorasTotales = proyectoDTO.HorasTotales,
                Estado = "Pendiente",  // Estado inicial
                HorasTrabajadas = 0,   // Por defecto 0
                FechaCreacion = DateTime.UtcNow
            };

            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();

            return proyecto;
        }

        // Obtener todos los proyectos
        public async Task<List<Proyecto>> ObtenerProyectosAsync()
        {
            return await _dbContext.Proyectos.ToListAsync();
        }

        // Obtener un proyecto por ID
        public async Task<Proyecto> ObtenerProyectoPorIdAsync(int id)
        {
            return await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.Id == id);
        }

        // Actualizar un proyecto existente
        public async Task<bool> ActualizarProyectoAsync(int id, ProyectoDTO proyectoDTO)
        {
            var proyectoExistente = await _dbContext.Proyectos.FindAsync(id);

            if (proyectoExistente == null)
            {
                return false; // El proyecto no existe
            }

            proyectoExistente.Nombre = proyectoDTO.Nombre;
            proyectoExistente.Descripcion = proyectoDTO.Descripcion;
            proyectoExistente.HorasTotales = proyectoDTO.HorasTotales;

            _dbContext.Proyectos.Update(proyectoExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Eliminar un proyecto
        public async Task<bool> EliminarProyectoAsync(int id)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return false; // El proyecto no existe
            }

            _dbContext.Proyectos.Remove(proyecto);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Actualizar estado de un proyecto
        public async Task<bool> ActualizarEstadoProyectoAsync(int id, string nuevoEstado)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);

            if (proyecto == null || (nuevoEstado != "Pendiente" && nuevoEstado != "En progreso" && nuevoEstado != "Finalizado"))
            {
                return false; // El proyecto no existe o el estado no es válido
            }

            proyecto.Estado = nuevoEstado;
            _dbContext.Proyectos.Update(proyecto);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Agregar horas trabajadas a un proyecto
        public async Task<bool> AgregarHorasTrabajadasAsync(int id, int horasTrabajadas)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);

            if (proyecto == null || horasTrabajadas < 0)
            {
                return false; // El proyecto no existe o las horas trabajadas son inválidas
            }

            proyecto.HorasTrabajadas += horasTrabajadas;

            // Verificar que las horas trabajadas no superen las horas totales
            if (proyecto.HorasTrabajadas > proyecto.HorasTotales)
            {
                proyecto.HorasTrabajadas = proyecto.HorasTotales; // Limitar a las horas totales
            }

            _dbContext.Proyectos.Update(proyecto);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
