using Microsoft.EntityFrameworkCore;
using BlazorRegistroUsuarios.Data;
using BlazorRegistroUsuarios.Data.Models;
using BlazorRegistroUsuarios.Services;

namespace BlazorRegistroUsuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioRegistrador?> ObtenerPorIdAsync(int id)
        {
            return await _context.UsuariosRegistradores.FindAsync(id);
        }

        public async Task<List<UsuarioRegistrador>> ObtenerTodosAsync()
        {
            return await _context.UsuariosRegistradores
                .OrderByDescending(u => u.FechaRegistro)
                .ToListAsync();
        }

        public async Task<bool> CrearAsync(UsuarioRegistrador usuario)
        {
            try
            {
                usuario.Clave = BCrypt.Net.BCrypt.HashPassword(usuario.Clave);
                _context.UsuariosRegistradores.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ExisteDocumentoAsync(string numeroDocumento)
        {
            return await _context.UsuariosRegistradores
                .AnyAsync(u => u.NumeroDocumento == numeroDocumento);
        }

        public async Task<bool> ExisteCorreoAsync(string correo)
        {
            return await _context.UsuariosRegistradores
                .AnyAsync(u => u.Correo == correo);
        }

        public async Task<UsuarioRegistrador> CrearUsuarioAsync(UsuarioRegistrador usuario)
        {
            // Hashear la contraseña
            usuario.Clave = BCrypt.Net.BCrypt.HashPassword(usuario.Clave);
            
            // Establecer la fecha de registro
            usuario.FechaRegistro = DateTime.UtcNow;
            
            // Asegurarse de que el usuario esté activo por defecto
            usuario.Activo = true;
            
            // Si no se especifica un rol, asignar "Registrador" por defecto
            if (string.IsNullOrEmpty(usuario.Permiso))
            {
                usuario.Permiso = "Registrador";
            }

            _context.UsuariosRegistradores.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}