using Microsoft.EntityFrameworkCore;
using BlazorRegistroUsuarios.Data;
using BlazorRegistroUsuarios.Data.Models;
using BlazorRegistroUsuarios.Services;

namespace BlazorRegistroUsuarios.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioRegistrador?> LoginAsync(string correo, string clave)
        {
            var usuario = await _context.UsuariosRegistradores
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Activo);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(clave, usuario.Clave))
                return null;

            return usuario;
        }

        public async Task<bool> EsAdministrador(string correo)
        {
            var usuario = await _context.UsuariosRegistradores
                .FirstOrDefaultAsync(u => u.Correo == correo);
            
            return usuario?.Permiso == "Administrador";
        }

        public void Logout()
        {
            // Implement logout logic if needed
        }
    }
}