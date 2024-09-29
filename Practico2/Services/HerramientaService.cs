using Microsoft.EntityFrameworkCore;
using Practico2.Data;
using Practico2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practico2.Services
{
    public class HerramientaService
    {
        private readonly EjemploDbContext _dbContext;

        public HerramientaService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Crear una nueva herramienta
        public async Task<Herramientas> CrearHerramientaAsync(Herramientas herramienta)
        {
            if (string.IsNullOrWhiteSpace(herramienta.Nombre))
            {
                throw new ArgumentException("El nombre de la herramienta es obligatorio.");
            }

            // Verificar si la herramienta ya existe
            var herramientaExistente = await _dbContext.Herramientas
                .FirstOrDefaultAsync(h => h.Nombre == herramienta.Nombre);

            if (herramientaExistente != null)
            {
                throw new InvalidOperationException("La herramienta ya existe.");
            }

            _dbContext.Herramientas.Add(herramienta);
            await _dbContext.SaveChangesAsync();

            return herramienta;
        }

        // Obtener todas las herramientas
        public async Task<List<Herramientas>> ObtenerHerramientasAsync()
        {
            return await _dbContext.Herramientas.ToListAsync();
        }

        // Obtener una herramienta por ID
        public async Task<Herramientas> ObtenerHerramientaPorIdAsync(int id)
        {
            return await _dbContext.Herramientas.FirstOrDefaultAsync(h => h.Id == id);
        }

        // Actualizar una herramienta existente
        public async Task<bool> ActualizarHerramientaAsync(int id, Herramientas herramienta)
        {
            var herramientaExistente = await _dbContext.Herramientas.FindAsync(id);

            if (herramientaExistente == null)
            {
                return false; // La herramienta no existe
            }

            if (string.IsNullOrWhiteSpace(herramienta.Nombre))
            {
                throw new ArgumentException("El nombre de la herramienta es obligatorio.");
            }

            // Actualizar los campos de la herramienta
            herramientaExistente.Nombre = herramienta.Nombre;

            _dbContext.Herramientas.Update(herramientaExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Eliminar una herramienta
        public async Task<bool> EliminarHerramientaAsync(int id)
        {
            var herramienta = await _dbContext.Herramientas.FindAsync(id);

            if (herramienta == null)
            {
                return false; // La herramienta no existe
            }

            _dbContext.Herramientas.Remove(herramienta);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
