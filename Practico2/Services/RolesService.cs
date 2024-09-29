using Microsoft.EntityFrameworkCore;
using Practico2.Data;
using Practico2.Models;

namespace Practico2.Services
{
    public class RolesService
    {
        private readonly EjemploDbContext _dbContext;

        public RolesService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtener un rol por ID
        public async Task<Rol> ObtenerRolPorIdAsync(int id)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

