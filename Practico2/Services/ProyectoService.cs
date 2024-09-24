using Practico2.Models;
using Practico2.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practico2.Services
{
    public class ProyectoService
    {
        private readonly DbContext _context;

        public ProyectoService(DbContext context)
        {
            _context = context;
        }

        // Método Index: Obtener lista de proyectos
        public async Task<List<Proyecto>> Index()
        {
            // Obtener todos los proyectos desde la base de datos
            return await _context.Set<Proyecto>().ToListAsync();
        }

        // Método Show: Obtener un proyecto por su ID
        public async Task<Proyecto> Show(int id)
        {
            // Buscar un proyecto específico por su ID
            var proyecto = await _context.Set<Proyecto>().FindAsync(id);
            return proyecto;
        }

        // Método Create: Crear un nuevo proyecto
        public async Task<bool> Create(ProyectoDTO proyectoDTO)
        {
            // Crear una nueva instancia de Proyecto a partir de ProyectoDTO
            var nuevoProyecto = new Proyecto
            {
                Nombre = proyectoDTO.Nombre,
                Descripcion = proyectoDTO.Descripcion,
                Estado = "Pendiente",
                HorasTotales = proyectoDTO.HorasTotales,
                HorasTrabajadas = 0,
                FechaCreacion = DateTime.Now
            };

            // Insertar el nuevo proyecto en la base de datos
            _context.Set<Proyecto>().Add(nuevoProyecto);
            var result = await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

            return result > 0; // Retorna true si se guardó correctamente
        }

        // Método Update: Actualizar un proyecto existente
        public async Task<bool> Update(int id, ProyectoDTO proyectoDTO)
        {
            // Buscar el proyecto por su ID
            var proyectoExistente = await _context.Set<Proyecto>().FindAsync(id);

            if (proyectoExistente == null)
            {
                return false; // El proyecto no existe
            }

            // Actualizar los valores del proyecto con los datos del DTO
            proyectoExistente.Nombre = proyectoDTO.Nombre;
            proyectoExistente.Descripcion = proyectoDTO.Descripcion;
            proyectoExistente.HorasTotales = proyectoDTO.HorasTotales;

            // Guardar los cambios en la base de datos
            var result = await _context.SaveChangesAsync();

            return result > 0; // Retorna true si se actualizó correctamente
        }

        // Método Delete: Eliminar un proyecto existente
        public async Task<bool> Delete(int id)
        {
            // Buscar el proyecto por su ID
            var proyectoExistente = await _context.Set<Proyecto>().FindAsync(id);

            if (proyectoExistente == null)
            {
                return false; // El proyecto no existe
            }

            // Eliminar el proyecto de la base de datos
            _context.Set<Proyecto>().Remove(proyectoExistente);
            var result = await _context.SaveChangesAsync();

            return result > 0; // Retorna true si se eliminó correctamente
        }
    }
}
