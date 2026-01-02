using BlazorRegistroUsuarios.Data.Models;

namespace BlazorRegistroUsuarios.Services
{
    public interface IAuthService
    {
        Task<UsuarioRegistrador?> LoginAsync(string correo, string clave);
        Task<bool> EsAdministrador(string correo);
        void Logout();
    }
}