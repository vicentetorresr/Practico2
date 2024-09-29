﻿using Microsoft.EntityFrameworkCore;
using Practico2.Data;
using Practico2.Models;
using Practico2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practico2.Services
{
    public class UsuarioService
    {
        private readonly EjemploDbContext _dbContext;

        public UsuarioService(EjemploDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Crear un nuevo usuario usando UsuarioDTO
        public async Task<Usuario> CrearUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            // Verificar si el email ya existe
            var usuarioExistente = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Email == usuarioDTO.Email);

            if (usuarioExistente != null)
            {
                throw new InvalidOperationException("El email ya está registrado.");
            }

            // Verificar que el RolId exista en la tabla Roles
            var rolExistente = await _dbContext.Roles.FindAsync(usuarioDTO.RolId);
            if (rolExistente == null)
            {
                throw new InvalidOperationException("El RolId no existe.");
            }

            // Crear un nuevo objeto Usuario basado en el DTO
            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                RolId = usuarioDTO.RolId
            };

            _dbContext.Usuarios.Add(nuevoUsuario);
            await _dbContext.SaveChangesAsync();

            return nuevoUsuario;
        }

        // Obtener todos los usuarios
        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        // Obtener un usuario por ID
        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        // Actualizar un usuario existente usando UsuarioDTO
        public async Task<bool> ActualizarUsuarioAsync(int id, UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = await _dbContext.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return false; // El usuario no existe
            }

            // Verificar que el RolId exista en la tabla Roles
            var rolExistente = await _dbContext.Roles.FindAsync(usuarioDTO.RolId);
            if (rolExistente == null)
            {
                throw new InvalidOperationException("El RolId no existe.");
            }

            // Actualizar los campos del usuario basado en el DTO
            usuarioExistente.Nombre = usuarioDTO.Nombre;
            usuarioExistente.Apellido = usuarioDTO.Apellido;
            usuarioExistente.Email = usuarioDTO.Email;
            usuarioExistente.Password = usuarioDTO.Password;
            usuarioExistente.RolId = usuarioDTO.RolId;

            _dbContext.Usuarios.Update(usuarioExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Eliminar un usuario
        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return false; // El usuario no existe
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        // Obtener usuarios por Rol
        public async Task<List<Usuario>> ObtenerUsuariosPorRolAsync(int rolId)
        {
            return await _dbContext.Usuarios
                .Where(u => u.RolId == rolId)
                .ToListAsync();
        }
    }
}
